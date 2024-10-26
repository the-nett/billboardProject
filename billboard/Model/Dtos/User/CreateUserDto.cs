namespace billboard.Model.Dtos.User
{
    public class CreateUserDto
    {
        public int PeopleId { get; set; }
        public required string PeoplePassword { get; set; }

    }
}
