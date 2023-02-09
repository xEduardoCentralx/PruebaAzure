using System.ComponentModel.DataAnnotations;
namespace Campañas.Models
{
    public class MovimientoModel{
        public int  idMovimiento { get; set; }
        [Required(ErrorMessage = "El numero de factura es un campo obligatorio")]
        public string? factura { get; set; }
        [Required(ErrorMessage = "La nota de credito es un campo obligatorio")]
        public string? notaCredito { get; set; }
        [Required(ErrorMessage = "El mes es un campo obligatorio")]
        public string? mes { get; set; }
        [Required(ErrorMessage = "El concepto es un campo obligatorio")]
        public string? concepto { get; set; }
        [Required(ErrorMessage = "El gasto es un campo obligatorio")]
        public double? gasto { get; set; }
        [Required(ErrorMessage = "Los impuestos es un campo obligatorio")]
        public double? impuestos { get; set; }
        [Required(ErrorMessage = "El total es un campo obligatorio")]
        public string? tipo { get; set; }
        [Required(ErrorMessage = "El fecha del movimiento es un campo obligatorio")]
        public string? fecha { get; set; }
        [Required(ErrorMessage = "El id de la marca es un campo obligatorio")]
        public string? idMarca { get; set; }
        [Required(ErrorMessage = "El id del metodo de pago es un campo obligatorio")]
        public string? idPago { get; set; }
        [Required(ErrorMessage = "Tu id es un campo obligatorio")]
        public string? idEmpleado { get; set; }
    }
}
