using Microsoft.EntityFrameworkCore;
using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore;

public class MovimientosDbContext : DbContext
{
    public MovimientosDbContext(DbContextOptions<MovimientosDbContext> options) : base(options) {}

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Cuenta> Cuenta { get; set; }
    public DbSet<Movimiento> Movimiento { get; set; }
}