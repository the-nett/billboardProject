﻿namespace billboard.Model.Dtos.Rental
{
    public class CreateRentalDto
    {
        public int IdBillboard { get; set; }

        public int IdLessor { get; set; }

        public int IdTenant { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public int IdPayMethods { get; set; }

        public required string AdContent { get; set; }

        public required string ContractClauses { get; set; }

        public required string Observations { get; set; }
    }
}