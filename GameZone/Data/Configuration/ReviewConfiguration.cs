using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => new { r.GameId, r.UserId });


            builder.HasOne(r => r.Game)
                .WithMany(g => g.Reviews)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Rating)
                .IsRequired()
                .HasDefaultValue(1);


            builder.Property(r => r.Comment)
                .HasMaxLength(500);

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_Review_Rating", "[Rating] >= 1 AND [Rating] <= 5")
            );
            builder.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
