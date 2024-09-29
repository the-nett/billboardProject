namespace billboard.Model
{
    public class UserTypePermissions
    {
        public  int Id_permission { get; set; }
        public  int Id_Usertype { get; set; }
        //Navigation
        public  UserType UserType { get; set; }
        public  Permission Permission { get; set; }
    }
}
