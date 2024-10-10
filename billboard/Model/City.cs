using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public  required string CityName { get; set; }

        public bool StateDelete { get; set; }

        //Navigation
        public ICollection<Company> CitiesCompany { get; } = new List<Company>();
    }
}
