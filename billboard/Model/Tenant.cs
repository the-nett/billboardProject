using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        public  int UserId { get; set; }

        public  int UserTypeId { get; set; }

        public  UserType UserType { get; set; }
    }
}
