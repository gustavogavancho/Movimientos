using Movimientos.BIZ.Services.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.BIZ.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    public async Task<Cliente> CreateCliente(Cliente entity)
    {
        entity.Id = Guid.NewGuid();
        entity.Contraseña = BCrypt.Net.BCrypt.HashPassword("entity.Contraseña");
        Cliente createdResult = await _clienteRepository.Create(entity);

        return createdResult;
    }
}