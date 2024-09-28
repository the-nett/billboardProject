using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        public required int BillboardId { get; set; }

        public required int LessorId { get; set; }

        public required int TenantId { get; set; }

        public required DateTime RentalStartDate { get; set; }

        public required DateTime RentalEndDate { get; set; }

        public required int PayMethodsId { get; set; }

        public required string AdContent { get; set; }

        public required string ContractClauses { get; set; }

        public required string Observations { get; set; }
    }
}
