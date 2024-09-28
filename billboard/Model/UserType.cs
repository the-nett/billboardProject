using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class UserType
    {
        [Key]
        public required int Id_Usertype { get; set; }
        public required string Utype { get; set; }
    }
}
