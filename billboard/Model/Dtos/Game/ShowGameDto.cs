using System;

namespace billboard.Model.Dtos.Game
{
    public class ShowGameDto
    {
        public required int IdUser { get; set; }
        public required string PlayerEmail { get; set; }
        public required int Level { get; set; }
    }
}
