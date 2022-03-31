using Movimientos.COMMON.Enums;
using Movimientos.COMMON.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.API.Models;

public class CuentaModel : BaseEntityModel
{
    public long NumeroCuenta { get; set; }
    public Tipo Tipo { get; set; }
    [Column(TypeName = "decimal(14, 2)")] public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }
    public Guid ClienteId { get; set; }
}