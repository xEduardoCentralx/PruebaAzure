using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Campañas.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }
    [Required(ErrorMessage = "El nombre es un campo obligatorio")]
    public string? Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El apellido paterno es un campo obligatorio")]
    public string? ApPaterno { get; set; } = null!;
    [Required(ErrorMessage = "El apellido materno es un campo obligatorio")]
    public string? ApMaterno { get; set; } = null!;
    [Required(ErrorMessage = "El correo es un campo obligatorio")]
    public string? Correo { get; set; } = null!;
    [Required(ErrorMessage = "La constraseña es un campo obligatorio")]
    public string? Contra { get; set; } = null!;
    [Required(ErrorMessage = "El rol de trabajo es un campo obligatorio")]
    public string? Rol { get; set; } = null!;

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();
}
