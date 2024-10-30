namespace billboard.Model.Dtos.UserNaturalPerson
{
    public class UserLoginDto
    {
        public int IdPeople { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int IdUser { get; set; }
        public required int IdUserType { get; set; }
    }
}
