using EzPay.ServiceProvider.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ServiceProvider.Infrastructure.Confgurations
{
    public class ServiceProviderConfigurations : IEntityTypeConfiguration<ServiceProviderProfile>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProfile> builder)
        {
            builder.ToTable("ServiceProvider");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            builder.Property(x => x.ContactNo).HasColumnName("ContactNo").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Street).HasColumnName("Street").IsRequired();

            builder.Property(x => x.StreetNo).HasColumnName("StreetNo").HasMaxLength(15).IsRequired();

            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(15).IsRequired();

            builder.Property(x => x.Province).HasColumnName("Province").HasMaxLength(15).IsRequired();

            builder.Property(x => x.BRN).HasColumnName("BRN").HasMaxLength(15).IsRequired();           

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValueSql("GETUTCDATE()").IsRequired();

            builder.Property(x => x.ModifiedOn).HasColumnName("ModifiedOn");

            builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(0).IsRequired();
        }
    }
}