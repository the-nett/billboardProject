using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public  required string DocumentName { get; set; }

        //Navigation
        public ICollection<Person> Documents { get; } = new List<Person>();
    }
}
