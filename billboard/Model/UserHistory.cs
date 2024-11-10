using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class UserHistory
    {
        [Key]
        public int IdUserHistory {  get; set; }
        public int IdUser { get; set; }
        public int PeopleId { get; set; }

        public required string PeoplePassword { get; set; }

        public string PeopleSalt { get; set; }

        public DateTime Modified { get; set; }

        public required int IdUserType { get; set; }

        public bool StateDelete { get; set; }
        public int ModifyByPerson { get; set; }
        public string Action {  get; set; }

    }
}
