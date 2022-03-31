using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Exceptions;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore;

namespace Movimientos.BIZ.Repository;

public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
{
    private readonly MovimientosDbContext _context;

    public MovimientoRepository(MovimientosDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movimiento> CreateMovimiento(Movimiento entity)
    {
        entity.Id = Guid.NewGuid();
        var sumaRetiroDiario = await SumaRetiroDiario(entity.CuentaId);
        if (sumaRetiroDiario + entity.Valor < -1000)
            throw new LimiteRetiroDiarioException(entity.Valor, sumaRetiroDiario);

        var cuentaAsociada = await _context.Cuenta.FindAsync(entity.CuentaId);
        if (cuentaAsociada is null)
            throw new CuentaInexistenteException(entity.CuentaId);

        if (cuentaAsociada.SaldoInicial < entity.Valor)
            throw new SaldoInsuficienteException(entity.Valor, cuentaAsociada.SaldoInicial);
        else 
        {
            cuentaAsociada.SaldoInicial = cuentaAsociada.SaldoInicial + entity.Valor;
            _context.Cuenta.Attach(cuentaAsociada);
        }
            
        EntityEntry<Movimiento> createdResult = await _context.Movimiento.AddAsync(entity);
        await _context.SaveChangesAsync();

        return createdResult.Entity;
    }

    public async Task<decimal> SumaRetiroDiario(Guid cuentaId)
    {
        var sumaMovimientosDia = await _context.Movimiento.Where(x => x.CuentaId == cuentaId && x.Valor < 0).SumAsync(x => x.Valor);

        return sumaMovimientosDia;
    }
}