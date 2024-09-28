using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        public required int UserId { get; set; }

        public required int UserTypeId { get; set; }
    }
}
