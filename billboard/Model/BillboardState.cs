using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class BillboardState
    {
        [Key]
        public int IdSate { get; set; }
        public  required string State { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<Billboard> BillboardState_Billboard { get; } = new List<Billboard>();
    }
}
