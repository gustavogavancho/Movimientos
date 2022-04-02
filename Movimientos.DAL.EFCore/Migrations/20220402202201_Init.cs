using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movimientos.DAL.EFCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Genero = table.Column<short>(type: "INTEGER", nullable: false),
                    Edad = table.Column<short>(type: "INTEGER", nullable: false),
                    Identificacion = table.Column<long>(type: "INTEGER", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumeroCuenta = table.Column<long>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<short>(type: "INTEGER", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<short>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CuentaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Contraseña", "Direccion", "Edad", "Estado", "FechaCreacion", "FechaModificacion", "Genero", "Identificacion", "Nombre", "Telefono" },
                values: new object[] { new Guid("6e381eb3-b59a-4354-bdf5-d05829cc3bfe"), "123456789", "Psje. Limatambo 121, Tarapoto, San Martín, San Martín, Perú", (short)27, true, new DateTime(2022, 4, 2, 15, 22, 1, 454, DateTimeKind.Local).AddTicks(4095), new DateTime(2022, 4, 2, 15, 22, 1, 454, DateTimeKind.Local).AddTicks(4096), (short)1, 73215945L, "Gustavo Gavancho León", 946585141L });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "Id", "ClienteId", "Estado", "FechaCreacion", "FechaModificacion", "NumeroCuenta", "SaldoInicial", "Tipo" },
                values: new object[] { new Guid("0bb27fe1-5fe2-4769-bf2f-94f052dad382"), new Guid("6e381eb3-b59a-4354-bdf5-d05829cc3bfe"), true, new DateTime(2022, 4, 2, 15, 22, 1, 454, DateTimeKind.Local).AddTicks(4219), new DateTime(2022, 4, 2, 15, 22, 1, 454, DateTimeKind.Local).AddTicks(4220), 130195L, 2000m, (short)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_ClienteId",
                table: "Cuenta",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_CuentaId",
                table: "Movimiento",
                column: "CuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
