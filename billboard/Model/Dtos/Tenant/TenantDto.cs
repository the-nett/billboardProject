namespace billboard.Model.Dtos.Tenant
{
    public class TenantDto
    {
        public int IdTenant { get; set; }

        public int UserId { get; set; }

        public int IdUserType { get; set; }

        public bool StateDelete { get; set; }
    }
}
