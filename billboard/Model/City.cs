using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public required string CityName { get; set; }

        public required int CatalogId { get; set; }
    }
}
