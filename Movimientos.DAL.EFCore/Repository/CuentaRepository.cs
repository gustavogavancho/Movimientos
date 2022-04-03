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

    public async Task<IEnumerable<Cuenta>> GetEstadoCuenta(Guid clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        IEnumerable<Cuenta> entity = await _context.Cuenta
            .Include(x => x.Movimientos)
            .Include(x=> x.Cliente)
            .Where(x => x.ClienteId == clienteId && 
            (x.Movimientos.Any(y=> y.FechaCreacion.Date >= fechaInicio.Date && y.FechaCreacion.Date <= fechaFin.Date))).ToListAsync();

        return entity;
    }
}