namespace billboard.Model.Dtos.Tenant
{
    public class CreateTenantDto
    {
        public int UserId { get; set; }

        public int IdUserType { get; set; }

        public bool StateDelete { get; set; }
    }
}
