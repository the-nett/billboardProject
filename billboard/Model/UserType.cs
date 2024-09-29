using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class UserType
    {
        [Key]
        public  int Id_Usertype { get; set; }
        public  string Utype { get; set; }
    }
}
