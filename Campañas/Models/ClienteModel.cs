using System.ComponentModel.DataAnnotations;
namespace Campañas.Models
{
    public class ClienteModel{

        /*Estan haciendo referencia a las diferentes columnas de la base de datos,
        deben estar escritar igual que en la BD*/
        public int idCliente { get; set; }
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El apellido paterno es un campo obligatorio")]
        public string? apPaterno { get; set; }
        [Required(ErrorMessage = "El apellido materno es un campo obligatorio")]
        public string? apMaterno { get; set; }
        [Required(ErrorMessage = "La empresa es un campo obligatorio")]
        public string? empresa { get; set; }
        [Required(ErrorMessage = "El tipo de movimiento un campo obligatorio")]
        public string? tipo { get; set; }
        [Required(ErrorMessage = "La fecha del movimiento un campo obligatorio")]
        public string? fecha { get; set; }
        [Required(ErrorMessage = "Tu ID es un campo obligatorio")]
        public int idEmpleado { get; set; }

    }
}
