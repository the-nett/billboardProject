using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Tenant
    {
        [Key]
        public int IdTenant { get; set; }

        public  int UserId { get; set; }

        public  int IdUserType { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<Rental> Tenant_Rental { get; } = new List<Rental>();
        public UserType UserType { get; set; }
    }
}
