namespace billboard.Model.Dtos.Person
{
    public class PersonDto
    {
        public int IdPeople { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required int IdDocumentType { get; set; }

        public required string DocumentNumb { get; set; }

        public required string Occupation { get; set; }

        public DateTime BirthDate { get; set; }

        public required string Email { get; set; }


        public string PhoneNumber { get; set; }

        public int IdUserType { get; set; }

        public DateTime Date { get; set; }

        public bool StateDelete { get; set; }
    }
}
