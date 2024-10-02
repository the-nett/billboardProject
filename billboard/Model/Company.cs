using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }

        public  string Company_Name { get; set; }

        public  int IdIndustry { get; set; }

        public  string NIT { get; set; }

        public  string Owner_Name { get; set; }
      
        public  string Company_Direction { get; set; }

        public  int IdCity { get; set; }

        public  string Phone_Number { get; set; }

        public  string Corporate_Email { get; set; }

        public  int IdResponsible { get; set; }
        public  string Password { get; set; }

        public  string Company_Salt { get; set; }

        public  int Id_User_Type { get; set; }

        public  DateTime Date { get; set; }

        //Navigation
        public  Industry Industry { get; set; }
        public  City City { get; set; }
        public  Responsible Responsible { get; set; }   
        public  UserType UserType { get; set; }  

    }
}
