using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore;

namespace Movimientos.BIZ.Repository;

public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
{
    public CuentaRepository(MovimientosDbContext context) : base(context) {}
}