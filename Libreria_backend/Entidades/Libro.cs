using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_backend.Entidades
{
    public class Libro
    {
        [Key]
        public long Libro_id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres.")]
        public string Titulo { get; set; }

        [Range(1000, 9000, ErrorMessage = "Debe ingresar un año válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de páginas debe ser mayor que 0.")]
        public int Cantidad_paginas { get; set; }

        public long Autor_id { get; set; }

        [ForeignKey("Autor_id")]
        public Autor Autor { get; set; }
    }
}
