using System;

namespace billboard.Model.Dtos.Game
{
    public class GameDto
    {
        public int IdGame { get; set; }
        public required int IdUser { get; set; }
        public required string PlayerEmail { get; set; }
        public required TimeSpan LevelTime { get; set; } 
        public required int Level { get; set; }
    }
}
