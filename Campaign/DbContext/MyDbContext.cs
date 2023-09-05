using Microsoft.EntityFrameworkCore;

namespace Campaign.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<OrganizationModel> Campaigns { get; set; }

    }
}
