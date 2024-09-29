using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public  string DocumentName { get; set; }
    }
}
