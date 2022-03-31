﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movimientos.DAL.EFCore;

#nullable disable

namespace Movimientos.DAL.EFCore.Migrations
{
    [DbContext(typeof(MovimientosDbContext))]
    partial class MovimientosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Movimientos.COMMON.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Edad")
                        .HasColumnType("smallint");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<short>("Genero")
                        .HasColumnType("smallint");

                    b.Property<long>("Identificacion")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefono")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f807360-1cdb-40b9-a797-8a0ae3d2bf59"),
                            Contraseña = "123456789",
                            Direccion = "Psje. Limatambo 121, Tarapoto, San Martín, San Martín, Perú",
                            Edad = (short)27,
                            Estado = true,
                            FechaCreacion = new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5190),
                            FechaModificacion = new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5198),
                            Genero = (short)1,
                            Identificacion = 73215945L,
                            Nombre = "Gustavo Gavancho León",
                            Telefono = 946585141L
                        });
                });

            modelBuilder.Entity("Movimientos.COMMON.Models.Cuenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<long>("NumeroCuenta")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(14,2)");

                    b.Property<short>("Tipo")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuenta");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3d8f4fe0-1c67-487e-8b49-7f8951cadc39"),
                            ClienteId = new Guid("9f807360-1cdb-40b9-a797-8a0ae3d2bf59"),
                            Estado = true,
                            FechaCreacion = new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5295),
                            FechaModificacion = new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5295),
                            NumeroCuenta = 130195L,
                            SaldoInicial = 2000m,
                            Tipo = (short)1
                        });
                });

            modelBuilder.Entity("Movimientos.COMMON.Models.Movimiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CuentaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(14,2)");

                    b.Property<short>("Tipo")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(14,2)");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Movimiento");
                });

            modelBuilder.Entity("Movimientos.COMMON.Models.Cuenta", b =>
                {
                    b.HasOne("Movimientos.COMMON.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Movimientos.COMMON.Models.Movimiento", b =>
                {
                    b.HasOne("Movimientos.COMMON.Models.Cuenta", null)
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Movimientos.COMMON.Models.Cuenta", b =>
                {
                    b.Navigation("Movimientos");
                });
#pragma warning restore 612, 618
        }
    }
}
