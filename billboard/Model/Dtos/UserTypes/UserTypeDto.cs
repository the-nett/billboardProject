using System.ComponentModel.DataAnnotations;
namespace billboard.Model.Dtos.UserTypes
{
    public class UserTypeDto
    {
        public int Id_Usertype { get; set; }
        public string Utype { get; set; }
        public bool StateDelete { get; set; }
    }
}
