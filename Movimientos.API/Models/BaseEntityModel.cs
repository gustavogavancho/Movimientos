using System.ComponentModel.DataAnnotations;

namespace Movimientos.API.Models;

public class BaseEntityModel
{
    [Key]
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}