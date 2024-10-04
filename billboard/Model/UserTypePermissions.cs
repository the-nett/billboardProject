namespace billboard.Model
{
    public class UserTypePermissions
    {
        public   int Id_permission { get; set; }
        public   int Id_Usertype { get; set; }
        //Navigation
        public Permission Permission { get; set; }
        public UserType UserType { get; set; }
    }
}
