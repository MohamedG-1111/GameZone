using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class GamedeviceConfiguration : IEntityTypeConfiguration<Gamedevice>
    {
        public void Configure(EntityTypeBuilder<Gamedevice> builder)
        {
            builder.HasOne(gd => gd.Game)
                .WithMany(g => g.Gamedevices)
                .HasForeignKey(gd => gd.GameId);

            builder.HasOne(gd => gd.Device)
                .WithMany(d => d.Gamedevices)
                .HasForeignKey(gd => gd.DeviceId);
            builder.HasKey(gd => new { gd.GameId, gd.DeviceId });
        }
    }
}
