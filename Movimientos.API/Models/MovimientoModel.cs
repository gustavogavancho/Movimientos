using Movimientos.COMMON.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.API.Models;

public class MovimientoModel : BaseEntityModel
{
    public Tipo Tipo { get; set; }
    [Column(TypeName = "decimal(14, 2)")] public decimal Valor { get; set; }
    public bool Estado { get; set; }
    public Guid CuentaId { get; set; }
}