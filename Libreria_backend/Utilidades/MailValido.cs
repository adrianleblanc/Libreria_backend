using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Libreria_backend.Utilidades
{
    public class MailValido : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex rgx = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            if (!rgx.IsMatch(value.ToString()))
            {
                return new ValidationResult("El correo no es válido");
            }

            return ValidationResult.Success;
        }
    }
}
