using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Tenant
    {
        [Key]
        public int IdTenant { get; set; }

        public  int UserId { get; set; }

        public  int UserTypeId { get; set; }

        //Navigation
        public ICollection<Rental> Tenant_Rental { get; } = new List<Rental>();
    }
}
