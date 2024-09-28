using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Industry
    {
        [Key]
        public int IndustryId { get; set; }

        public required string IndustryName { get; set; }
    }
}
