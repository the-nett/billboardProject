using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class PayMethods
    {
        [Key]
        public int IdPayMethod { get; set; }

        public  required string PayMethod { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<Rental> PayMethodsRental { get; } = new List<Rental>();
    }
}
