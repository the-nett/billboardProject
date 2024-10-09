using billboard.Migrations;
using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Person
    {
        [Key]
        public int IdPeople { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int IdDocumentType { get; set; }

        public string DocumentNumb { get; set; }

        public string Occupation { get; set; }

        public  DateTime BirthDate { get; set; }

        public  string Email { get; set; }


        public  string PhoneNumber { get; set; }

        public  int IdUserType { get; set; }

        public  DateTime Date { get; set; }

        public bool StateDelete { get; set; }

        // Propiedad de navegación
        public  UserType UserType { get; set; }
        public  Document Document { get; set; }
        public Responsible Responsible { get; set; }
        public User User { get; set; }
    }
}
