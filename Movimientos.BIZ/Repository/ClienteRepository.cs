using Movimientos.BIZ.Repository.Interfaces;
using Movimientos.COMMON.Models;
using Movimientos.DAL.EFCore;

namespace Movimientos.BIZ.Repository;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(MovimientosDbContext context) : base(context) {}
}
