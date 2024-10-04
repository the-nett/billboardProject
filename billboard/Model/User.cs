using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public  int PeopleId { get; set; }

        public  required string PeoplePassword { get; set; }

        public  required string PeopleSalt { get; set; }

        public  DateTime Date { get; set; }

        public  required int IdUserType { get; set; }

        //Navigation
        public  Person Person { get; set; }
        public  UserType UserType { get; set; }
    }
}
