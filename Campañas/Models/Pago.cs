using System;
using System.Collections.Generic;

namespace Campañas.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();
}
