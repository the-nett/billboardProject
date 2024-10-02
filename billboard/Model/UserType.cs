using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace billboard.Model
{
    public class UserType
    {
        [Key]
        public  int Id_Usertype { get; set; }
        public  string Utype { get; set; }
        //Navigation
        public ICollection<User> Users { get; } = new List<User>();
        public ICollection<Person> People { get; } = new List<Person>();
        public ICollection<Company> UserTypeCompany { get; } = new List<Company>();
    }
}
