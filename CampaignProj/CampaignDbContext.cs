using CampaignProj.Models;
using Microsoft.EntityFrameworkCore;

namespace CampaignProj
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}
