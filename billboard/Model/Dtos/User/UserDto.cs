namespace billboard.Model.Dtos.User
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public int PeopleId { get; set; }

        public required string PeoplePassword { get; set; }

        public string PeopleSalt { get; set; }

        public DateTime Date { get; set; }

        public required int IdUserType { get; set; }

        public bool StateDelete { get; set; }
    }
}
