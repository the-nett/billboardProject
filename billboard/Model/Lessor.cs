using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Lessor
    {
        [Key]
        public int LessorId { get; set; }

        public  int UserId { get; set; }

        public  int UserTypeId { get; set; }

        //Navigation
        public  UserType UserType { get; set; }

    }
}
