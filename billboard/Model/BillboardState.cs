using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class BillboardState
    {
        [Key]
        public int IdSate { get; set; }
        public  string State { get; set; }

        //Navigation
        public ICollection<Billboard> BillboardState_Billboard { get; } = new List<Billboard>();
    }
}
