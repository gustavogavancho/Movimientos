using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore;

namespace Movimientos.BIZ.Repository
{
    public class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(MovimientosDbContext context) : base(context) {}
    }
}
