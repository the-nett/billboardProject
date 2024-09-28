using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Company
    {
        [Key]
        public int Company_Id { get; set; }

        public required string Company_Name { get; set; }

        public required int Industry_Id { get; set; }

        public required string NIT { get; set; }

        public required string Owner_Name { get; set; }
      
        public required string Company_Direction { get; set; }

        public required int City_Id { get; set; }

        public required string Phone_Number { get; set; }

        public required string Corporate_Email { get; set; }

        public required int Responsible_Id { get; set; }
        public required string Password { get; set; }

        public required string Company_Salt { get; set; }

        public required int Id_User_Type { get; set; }

        public required DateTime Date { get; set; }
    }
}
