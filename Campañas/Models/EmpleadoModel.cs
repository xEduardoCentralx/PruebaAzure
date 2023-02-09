 using System.ComponentModel.DataAnnotations;
namespace Campañas.Models
{
    public class EmpleadoModel{
        /*Estan haciendo referencia a las diferentes columnas de la base de datos,
        deben estar escritar igual que en la BD*/
        public int idEmpleado { get; set; }
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El apellido paterno es un campo obligatorio")]
        public string? apPaterno { get; set; }
        [Required(ErrorMessage = "El apellido materno es un campo obligatorio")]
        public string? apMaterno { get; set; }
        [Required(ErrorMessage = "El correo es un campo obligatorio")]
        public string? correo { get; set; }
        [Required(ErrorMessage = "La constraseña es un campo obligatorio")]
        public string? contra { get; set; }
        [Required(ErrorMessage = "El rol de trabajo es un campo obligatorio")]
        public string? rol { get; set; }

    }
}
