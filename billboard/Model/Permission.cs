using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Permission
    {
        [Key]
        public int Id_Permission { get; set; }

        public  string Permission_ { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<UserTypePermissions> UserTypePermission { get; set; } = new List<UserTypePermissions>();
    }
}
