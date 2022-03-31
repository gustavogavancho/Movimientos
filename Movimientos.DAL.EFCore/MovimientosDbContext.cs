using Microsoft.EntityFrameworkCore;
using Movimientos.COMMON.Enums;
using Movimientos.COMMON.Models;

namespace Movimientos.DAL.EFCore;

public class MovimientosDbContext : DbContext
{
    public MovimientosDbContext(DbContextOptions<MovimientosDbContext> options) : base(options) { }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Cuenta> Cuenta { get; set; }
    public DbSet<Movimiento> Movimiento { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var guid = Guid.NewGuid();

        modelBuilder.Entity<Cliente>().HasData(new Cliente
        {
            Id = guid,
            Contraseña = "123456789",
            Nombre = "Gustavo Gavancho León",
            Telefono = 946585141,
            Edad = 27,
            Identificacion = 73215945,
            Direccion = "Psje. Limatambo 121, Tarapoto, San Martín, San Martín, Perú",
            Genero = Genero.Masculino,
            Estado = true,
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now
        });

        modelBuilder.Entity<Cuenta>().HasData(new Cuenta
        {
            Id = Guid.NewGuid(),
            NumeroCuenta = 130195,
            Tipo = Tipo.Ahorro,
            SaldoInicial = 2000,
            Estado = true,
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            ClienteId = guid,
            //Cliente = new Cliente 
            //{
            //    Id = guid,
            //    Contraseña = "123456789",
            //    Nombre = "Gustavo Gavancho León",
            //    Telefono = 946585141,
            //    Edad = 27,
            //    Identificacion = 73215945,
            //    Direccion = "Psje. Limatambo 121, Tarapoto, San Martín, San Martín, Perú",
            //    Genero = Genero.Masculino,
            //    Estado = true
            //}
        });
    }
}