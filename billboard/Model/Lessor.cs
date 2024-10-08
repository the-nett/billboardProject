using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Lessor
    {
        [Key]
        public int IdLessor { get; set; }

        public  int IdUser { get; set; }

        public  int IdUserType { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<Rental> Lessor_Rental { get; } = new List<Rental>();
        public ICollection<Billboard> Lessor_Billboard { get; } = new List<Billboard>();
        public UserType UserType { get; set; }
        public object LessorName { get; internal set; }
    }
}
