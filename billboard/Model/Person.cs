using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Person
    {
        [Key]
        public int PeopleId { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required int DocumentType { get; set; }

        public required string DocumentNumb { get; set; }

        public required string Occupation { get; set; }

        public required DateTime BirthDate { get; set; }

        public required string Email { get; set; }


        public required string PhoneNumber { get; set; }

        public required int RoleId { get; set; }

        public required int IdUserType { get; set; }

        public required DateTime Date { get; set; }

    }
}
