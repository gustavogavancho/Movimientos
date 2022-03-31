using System.ComponentModel.DataAnnotations;

namespace Movimientos.COMMON.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}