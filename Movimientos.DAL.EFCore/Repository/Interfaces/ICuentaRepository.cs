using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore.Repository.Interfaces;

public interface ICuentaRepository : IGenericRepository<Cuenta> 
{
    Task<Cuenta> GetEstadoCuenta(Guid clienteId, DateTime fechaInicio, DateTime fechaFin);
}