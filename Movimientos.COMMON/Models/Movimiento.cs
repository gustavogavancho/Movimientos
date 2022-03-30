using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.COMMON.Models;

public class Movimiento : BaseEntity
{
    public string TipoMovimiento { get; set; }
    [Column(TypeName = "decimal(14, 2)")] public decimal Valor { get; set; }

    [Column(TypeName = "decimal(14, 2)")] public decimal Saldo { get; set; }
    public string Estado { get; set; }
}