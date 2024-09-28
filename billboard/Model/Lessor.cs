using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Lessor
    {
        [Key]
        public int LessorId { get; set; }

        public required int UserId { get; set; }

        public required int UserTypeId { get; set; }
    }
}
