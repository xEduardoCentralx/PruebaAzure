using System;
using System.Collections.Generic;

namespace Campañas.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApPaterno { get; set; } = null!;

    public string ApMaterno { get; set; } = null!;

    public string Empresa { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int IdEmpleado { get; set; }

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();
}
