using Microsoft.EntityFrameworkCore;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.DAL.EFCore.Repository;

public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
{
    private readonly MovimientosDbContext _context;

    public MovimientoRepository(MovimientosDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<decimal> SumaRetiroDiario(Guid cuentaId)
    {
        var sumaMovimientosDia = await _context.Movimiento.Where(x => x.CuentaId == cuentaId && x.Valor < 0).SumAsync(x => x.Valor);

        return sumaMovimientosDia;
    }
}
