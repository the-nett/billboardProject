using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
	public class Game
	{
		[Key]
		public int IdGame { get; set; }
		public required int IdUser { get; set; }
		public required string PlayerEmail { get; set; }
		public required TimeSpan LevelTime { get; set; }  // Almacena el tiempo transcurrido en el nivel
		public required int Level { get; set; }
	}
}
