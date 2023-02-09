using System.ComponentModel.DataAnnotations;
namespace Campañas.Models
{
    public class PagoModel{
        public int idPago { get; set; }
        [Required(ErrorMessage = "Tipo de pago es un campo obligatorio")]
        public string? nombre { get; set; }
    }
}
