using Movimientos.COMMON.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.COMMON.Models;

public class Cuenta : BaseEntity
{
    public long NumeroCuenta { get; set; }
    public Tipo Tipo { get; set; }
    [Column(TypeName = "decimal(14, 2)")] public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public IEnumerable<Movimiento> Movimientos { get; set; }
}