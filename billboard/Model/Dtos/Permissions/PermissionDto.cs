using System.ComponentModel.DataAnnotations;

namespace billboard.Model.Dtos.Permissions
{
    public class PermissionDto
    {
        public int Id_Permission { get; set; }
        public string Permission_ { get; set; }
        public bool StateDelete { get; set; }
    }
}
