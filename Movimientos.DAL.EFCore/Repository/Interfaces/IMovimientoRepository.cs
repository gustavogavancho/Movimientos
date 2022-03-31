using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore.Repository.Interfaces;

public interface IMovimientoRepository : IGenericRepository<Movimiento>
{
    Task<decimal> SumaRetiroDiario(Guid cuentaId);
}