using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class PayMethods
    {
        [Key]
        public int IdPayMethod { get; set; }

        public  string PayMethod { get; set; }

        //Navigation
        public ICollection<Rental> PayMethodsRental { get; } = new List<Rental>();
    }
}
