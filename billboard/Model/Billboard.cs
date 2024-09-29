using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class Billboard
    {
        [Key]
        public int BillboardId { get; set; }

        public  int LessorId { get; set; }

        public  string ImageUrl { get; set; }

        public  double Fee { get; set; }

        public  int BillboardStateId { get; set; }

        public  string LatitudeAndLongitude { get; set; }

        public  int BillboardTypeId { get; set; }

        public  bool State { get; set; }

        public  string Measures { get; set; }

        public  double FloorDistance { get; set; }

        public  bool Illumination { get; set; }

        public  DateTime InstallationDate { get; set; }

        public  int SimultaneousAds { get; set; }

        public  string Observations { get; set; }

        //Navigation
        public  BillboardState BillboardState { get; set; } 
        public  BillboardType BillboardType { get; set; }

    }
}
