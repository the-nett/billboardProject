using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public  int PeopleId { get; set; }

        public  required string PeoplePassword { get; set; }

        public  string PeopleSalt { get; set; }

        public  DateTime Date { get; set; }

        public  required int IdUserType { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public  Person Person { get; set; }
        public  UserType UserType { get; set; }
        public Game Game { get; set; }
    }
}
