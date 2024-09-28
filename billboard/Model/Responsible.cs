using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Responsible
    {
        [Key]
        public int ResponsibleId { get; set; }

        public required int PeopleId { get; set; }

        public required int CompanyId { get; set; }
    }
}
