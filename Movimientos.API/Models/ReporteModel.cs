namespace Movimientos.API.Models;

public class ReporteModel
{
    public Guid ClienteId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}