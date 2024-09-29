using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class PayMethods
    {
        [Key]
        public int TenantId { get; set; }

        public  string PayMethod { get; set; }

    }
}
