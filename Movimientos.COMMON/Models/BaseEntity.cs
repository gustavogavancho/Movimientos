using System;
using System.ComponentModel.DataAnnotations;

namespace Movimientos.COMMON.Models;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
}