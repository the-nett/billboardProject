﻿using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos
{
    public class LoginCompanyDto
    {
        [EmailAddress, Required(ErrorMessage = "El correo es obligatorio")]
        public string Corporate_Email { get; set; }

        [EmailAddress, Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

    }
}
