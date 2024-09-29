using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        public  int BillboardId { get; set; }

        public  int LessorId { get; set; }

        public  int TenantId { get; set; }

        public  DateTime RentalStartDate { get; set; }

        public  DateTime RentalEndDate { get; set; }

        public  int PayMethodsId { get; set; }

        public  string AdContent { get; set; }

        public  string ContractClauses { get; set; }

        public  string Observations { get; set; }

        //Navigation
        public  Billboard Billboard { get; set; }
        public  Lessor Lessor { get; set; }
        public  Tenant Tenant { get; set; } 
        public  PayMethods PayMethods { get; set; }

    }
}
