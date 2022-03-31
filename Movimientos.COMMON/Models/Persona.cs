using Movimientos.COMMON.Enums;

namespace Movimientos.COMMON.Models;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public Genero Genero { get; set; }
    public short Edad { get; set; }
    public long Identificacion { get; set; }
    public string Direccion { get; set; }
    public long Telefono { get; set; }
}