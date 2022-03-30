namespace Movimientos.COMMON.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}