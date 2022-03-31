using Movimientos.COMMON.Models;

namespace Movimientos.BIZ.Services.Interfaces;

public interface IClienteService
{
    Task<Cliente> CreateCliente(Cliente entity);
}