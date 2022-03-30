using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.COMMON.Models;

public class Cuenta : BaseEntity
{
    public long NumeroCuenta { get; set; }
    public string TipoCuenta { get; set; }
    [Column(TypeName = "decimal(14, 2)")] public decimal SaldoInicial { get; set; }
    public string Estado { get; set; }
    public Cliente Cliente { get; set; }
    public IEnumerable<Movimiento> Movimientos { get; set; }
}