using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Campañas.Models
{
    public class PAjustadoModel{
        [Key]
        public int idHerramienta { get; set; }
        [Required(ErrorMessage = "La herramienta es un campo obligatorio")]
        public string? Herramienta { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Enero { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Febrero { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Marzo { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Abril { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Mayo { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Junio { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Julio { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Agosto { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Septiembre { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Octubre { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Noviembre { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? Diciembre { get; set; }
        [Required(ErrorMessage = "El valor minimo debe ser 0")]
        public decimal? SEvento { get; set; }

    }
}
