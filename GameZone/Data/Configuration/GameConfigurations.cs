using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(g => g.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CategoryId);
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(g => g.Description)
                   .IsRequired()
               .HasMaxLength(2500);

            builder.Property(g => g.Cover)
               .IsRequired()
               .HasMaxLength(500);

        }
    }
}
