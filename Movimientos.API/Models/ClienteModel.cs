using Movimientos.COMMON.Enums;
using System.ComponentModel.DataAnnotations;

namespace Movimientos.API.Models;

public class ClienteModel : BaseEntityModel
{
    public string Nombre { get; set; }
    public Genero Genero { get; set; }
    public short Edad { get; set; }
    public long Identificacion { get; set; }
    public string Direccion { get; set; }
    public long Telefono { get; set; }
    public string Contraseña { get; set; }
    public bool Estado { get; set; }
}