using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.UserTypes
{
    public class CreateUserTypeDto
    {
        [Required(ErrorMessage = "Es obligatorio digitar el tipo de usuario.")]
        public string Utype { get; set; }
    }
}
