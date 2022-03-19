using EzPay.ServiceProvider.Domain;
using Microsoft.EntityFrameworkCore;
using ServiceProvider.Infrastructure.Confgurations;

namespace ServiceProvider.Infrastructure
{
    public class EzJobContext : DbContext
    {
        public EzJobContext(DbContextOptions<EzJobContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceProviderConfigurations());
        }

        public DbSet<ServiceProviderProfile> ServiceProviders { get; set; }
    }
}
