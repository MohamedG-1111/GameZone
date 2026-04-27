using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(d => d.Icon)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
