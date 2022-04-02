using Movimientos.API.Models.CustomValidation;
using Movimientos.COMMON.Enums;

namespace Movimientos.API.Models;

public class MovimientoModel : BaseEntityModel
{
    public Tipo Tipo { get; set; }
    [NotZeroAttribute] public decimal Valor { get; set; }
    public bool Estado { get; set; }
    public Guid CuentaId { get; set; }
}