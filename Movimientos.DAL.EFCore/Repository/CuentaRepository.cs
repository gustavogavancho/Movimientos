using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.DAL.EFCore.Repository;

public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
{
    public CuentaRepository(MovimientosDbContext context) : base(context) { }
}