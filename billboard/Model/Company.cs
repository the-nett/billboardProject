using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }

        public  required string Company_Name { get; set; }

        public  int IdIndustry { get; set; }

        public  required string NIT { get; set; }

        public  required string Owner_Name { get; set; }
      
        public  required string Company_Direction { get; set; }

        public  int IdCity { get; set; }

        public  required string Phone_Number { get; set; }

        public  required string Corporate_Email { get; set; }

        public  required string Password { get; set; }

        public  required string Company_Salt { get; set; }

        public  int Id_User_Type { get; set; }

        public  DateTime Date { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public  Industry Industry { get; set; }
        public  City City { get; set; }   
        public  UserType UserType { get; set; }  

    }
}
