using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.Permissions
{
    public class CreatePermissionDto
    {
        [Required(ErrorMessage = "Es obligatorio digitar el permiso.")]
        public string Permission_ { get; set; }
    }
}
