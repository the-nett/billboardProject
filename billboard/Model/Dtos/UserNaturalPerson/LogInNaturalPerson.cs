using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.NaturalPerson
{
    public class LogInNaturalPerson
    {
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo password es obligatorio.")]
        public string PeoplePassword { get; set; }
    }
}
