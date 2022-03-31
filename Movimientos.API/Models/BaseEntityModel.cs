using System.ComponentModel.DataAnnotations;

namespace Movimientos.API.Models;

public class BaseEntityModel
{
    [Key]
    public Guid Id { get; set; }
}