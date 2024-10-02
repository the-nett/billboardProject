using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Industry
    {
        [Key]
        public int IndustryId { get; set; }

        public  string IndustryName { get; set; }

        //Navigation
        public ICollection<Company> Companies { get; } = new List<Company>();
    }
}
