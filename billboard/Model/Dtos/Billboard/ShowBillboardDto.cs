namespace billboard.Model.Dtos.Billboard
{
    public class ShowBillboardDto
    {
        public int IdBillboard { get; set; }
        public int IdLessor { get; set; }

        public required string ImageUrl { get; set; }

        public double Fee { get; set; }

        public int IdBillboardState { get; set; }

        public required string LatitudeAndLongitude { get; set; }

        public int IdBillboardType { get; set; }

        public bool State { get; set; }

        public required string Measures { get; set; }

        public double FloorDistance { get; set; }

        public bool Illumination { get; set; }

        public DateTime InstallationDate { get; set; }

        public int SimultaneousAds { get; set; }

        public required string Observations { get; set; }

        public bool StateDelete { get; set; }
    }
}
