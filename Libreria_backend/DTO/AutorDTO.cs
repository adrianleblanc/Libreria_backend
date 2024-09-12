using Libreria_backend.Utilidades;
using System.ComponentModel.DataAnnotations;

namespace Libreria_backend.DTO
{
    public class AutorDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RutValido]
        public string Rut { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MinLength(10, ErrorMessage = "Debe ingresar un nombre válido")]
        public string Nombre_completo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MailValido]
        public string Correo { get; set; }
    }
}
