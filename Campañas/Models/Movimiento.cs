using System;
using System.Collections.Generic;

namespace Campañas.Models;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public string Factura { get; set; } = null!;

    public string? NotaCredito { get; set; }

    public string? Mes { get; set; }

    public string? Concepto { get; set; }

    public double? Gasto { get; set; }

    public double? Impuestos { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int IdMarca { get; set; }

    public int IdPago { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual Pago IdPagoNavigation { get; set; } = null!;
}
