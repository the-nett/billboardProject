using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public  int PeopleId { get; set; }

        public  string PeoplePassword { get; set; }

        public  string PeopleSalt { get; set; }

        public  DateTime Date { get; set; }

        public  int IdUserType { get; set; }

        //Navigation
        public  Person Person { get; set; }
        public  UserType UserType { get; set; }
    }
}
