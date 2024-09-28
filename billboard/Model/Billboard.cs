using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Billboard
    {
        [Key]
        public int BillboardId { get; set; }

        public required int LessorId { get; set; }

        public required string ImageUrl { get; set; }

        public required double Fee { get; set; }

        public required int BillboardStateId { get; set; }

        public required string LatitudeAndLongitude { get; set; }

        public required int BillboardTypeId { get; set; }

        public required bool State { get; set; }

        public required string Measures { get; set; }

        public required double FloorDistance { get; set; }

        public required bool Illumination { get; set; }

        public required DateTime InstallationDate { get; set; }

        public required int SimultaneousAds { get; set; }

        public required string Observations { get; set; }
    }
}
