using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class BillboardState
    {
        [Key]
        public int Sate_Id { get; set; }
        public  string State { get; set; }
    }
}
