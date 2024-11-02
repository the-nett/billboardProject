using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.Company
{
    public class LoginCompanyDto
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Corporate_Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
