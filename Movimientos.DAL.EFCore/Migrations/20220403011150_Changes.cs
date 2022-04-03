using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movimientos.DAL.EFCore.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaldoInicial",
                table: "Cuenta",
                newName: "Saldo");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Movimiento",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInicial",
                table: "Movimiento",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoInicial",
                table: "Movimiento");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Cuenta",
                newName: "SaldoInicial");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Movimiento",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
