using Movimientos.COMMON.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movimientos.COMMON.Models;

public class Movimiento : BaseEntity
{
    public Tipo Tipo { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public Guid CuentaId { get; set; }
}