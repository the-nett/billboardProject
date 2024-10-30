namespace billboard.Model.Dtos.User
{
    public class UpdateUserDto
    {
        public int IdUser { get; set; }
        public int PeopleId { get; set; }

        public required string PeoplePassword { get; set; }


        public required int IdUserType { get; set; }

        public bool StateDelete { get; set; }
    }
}
