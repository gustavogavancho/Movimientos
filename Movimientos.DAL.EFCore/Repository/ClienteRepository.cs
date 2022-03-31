using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore.Repository.Interfaces;

namespace Movimientos.DAL.EFCore.Repository;
public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(MovimientosDbContext context) : base(context) 
    {
    }
}