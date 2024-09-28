using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public required int PeopleId { get; set; }

        //[MaxLength(90)]
        public required string PeoplePassword { get; set; }

        //[MaxLength(10)]
        public required string PeopleSalt { get; set; }

        public required DateTime Date { get; set; }

        public required int IdUserType { get; set; }
    }
}
