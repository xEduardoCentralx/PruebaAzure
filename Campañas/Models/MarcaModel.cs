using System.ComponentModel.DataAnnotations;
namespace Campañas.Models
{
    public class MarcaModel{
        public int idMarca { get; set; }
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El tipo de marca es un campo obligatorio")]
        public string? tipo { get; set; }
        [Required(ErrorMessage = "La fecha es un campo obligatorio")]
        public string? fecha { get; set; }
        [Required(ErrorMessage = "El del del cliente es un campo obligatorio")]
        public int? idCliente { get; set; }
        [Required(ErrorMessage = "Tu id es un campo obligatorio")]
        public int? idEmpleado { get; set; }
    }
}
