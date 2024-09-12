using System.ComponentModel.DataAnnotations;

namespace Libreria_backend.DTO
{
    public class LibroDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres.")]
        public string Titulo { get; set; }

        [Range(1000, 3000, ErrorMessage = "El año debe estar entre 1000 y 3000.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de páginas debe ser mayor que 0.")]
        public int Cantidad_paginas { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(12, ErrorMessage = "El campo {0} debe tener un formato válido.")]
        public string AutorRut { get; set; }
    }
}
