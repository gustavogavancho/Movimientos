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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<short>(type: "smallint", nullable: false),
                    Edad = table.Column<short>(type: "smallint", nullable: false),
                    Identificacion = table.Column<long>(type: "bigint", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCuenta = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                values: new object[] { new Guid("9f807360-1cdb-40b9-a797-8a0ae3d2bf59"), "123456789", "Psje. Limatambo 121, Tarapoto, San Martín, San Martín, Perú", (short)27, true, new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5190), new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5198), (short)1, 73215945L, "Gustavo Gavancho León", 946585141L });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "Id", "ClienteId", "Estado", "FechaCreacion", "FechaModificacion", "NumeroCuenta", "SaldoInicial", "Tipo" },
                values: new object[] { new Guid("3d8f4fe0-1c67-487e-8b49-7f8951cadc39"), new Guid("9f807360-1cdb-40b9-a797-8a0ae3d2bf59"), true, new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5295), new DateTime(2022, 3, 30, 23, 44, 18, 25, DateTimeKind.Local).AddTicks(5295), 130195L, 2000m, (short)1 });

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
