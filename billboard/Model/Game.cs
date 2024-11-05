using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
	public class Game
	{
		[Key]
		public int IdGame { get; set; }
		public required int IdUser { get; set; }
		public required string PlayerEmail { get; set; }
		public required int Level { get; set; }

		public User User { get; set; }
	}
}
