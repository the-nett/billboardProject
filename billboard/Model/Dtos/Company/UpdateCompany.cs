using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.Company
{
    public class UpdateCompany

    {
        public int IdCompany { get; set; }
        [Required(ErrorMessage = "El nombre de la compañía es obligatorio")]
        public string Company_Name { get; set; }

        [Required(ErrorMessage = "El sector de la empresa es obligatorio.")]
        public int IdIndustry { get; set; }

        [Required(ErrorMessage = "El NIT es obligatorio")]
        public string NIT { get; set; }

        [Required(ErrorMessage = "El nombre del propietario es obligatorio")]
        public string Owner_Name { get; set; }

        [Required(ErrorMessage = "La dirección de la compañía es obligatoria")]
        public string Company_Direction { get; set; }

        [Required(ErrorMessage = "La ciudad de la empresa es obligatoria.")]
        public int IdCity { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "El correo electrónico corporativo es obligatorio")]
        public string Corporate_Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }
    }
}
