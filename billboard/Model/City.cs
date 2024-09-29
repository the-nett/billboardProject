using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public  string CityName { get; set; }

        public  int CatalogId { get; set; }
    }
}
