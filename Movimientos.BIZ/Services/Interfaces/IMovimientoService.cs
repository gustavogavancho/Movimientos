using Movimientos.COMMON.Models;

namespace Movimientos.BIZ.Services.Interfaces;

public interface IMovimientoService
{
    Task<Movimiento> CreateMovimiento(Movimiento entity);
}