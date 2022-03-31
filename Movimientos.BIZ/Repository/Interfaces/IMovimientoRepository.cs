using Movimientos.COMMON.Models;

namespace Movimientos.BIZ.Repository.Interfaces;

public interface IMovimientoRepository : IGenericRepository<Movimiento> 
{
    Task<decimal> SumaRetiroDiario(Guid cuentaId);
    Task<Movimiento> CreateMovimiento(Movimiento entity);
}