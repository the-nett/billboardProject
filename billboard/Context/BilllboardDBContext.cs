using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Context
{
    public class BilllboardDBContext : DbContext
    {
        public BilllboardDBContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
