using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Rental
    {
        [Key]
        public int IdRental { get; set; }

        public  int IdBillboard { get; set; }

        public  int IdLessor { get; set; }

        public  int IdTenant { get; set; }

        public  DateTime RentalStartDate { get; set; }

        public  DateTime RentalEndDate { get; set; }

        public  int IdPayMethods { get; set; }

        public  required string AdContent { get; set; }

        public  required string ContractClauses { get; set; }

        public  required string Observations { get; set; }

        //Navigation
        public  Billboard Billboard { get; set; }
        public  Lessor Lessor { get; set; }
        public  Tenant Tenant { get; set; } 
        public  PayMethods PayMethods { get; set; }

    }
}
