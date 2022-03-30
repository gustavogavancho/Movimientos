namespace Movimientos.COMMON.Models;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public short Edad { get; set; }
    public Guid Identificacion { get; set; }
    public string Direccion { get; set; }
    public long Telefono { get; set; }
}