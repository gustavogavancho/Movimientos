using Microsoft.EntityFrameworkCore;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.DAL.EFCore.Repository;

public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
{
    private readonly MovimientosDbContext _context;

    public CuentaRepository(MovimientosDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cuenta> GetEstadoCuenta(Guid clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        Cuenta entity = await _context.Cuenta
            .Include(x => x.Movimientos)
            .SingleOrDefaultAsync(x => x.ClienteId == clienteId && 
            (x.Movimientos.Any(y=> y.FechaCreacion.Date >= fechaInicio.Date && y.FechaCreacion.Date <= fechaFin.Date)));

        return entity;
    }
}