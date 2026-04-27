using GameZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FullName)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.Property(u => u.EnabalNotifications)
                .HasDefaultValue(false);

            builder.Property(u => u.ImageUrl)
                .HasDefaultValue(string.Empty);

            builder.Property(u => u.Address)
                .IsRequired(true)
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email)
                .IsUnique();



            builder.ToTable(op =>
            {
                op.HasCheckConstraint("EmailCheck", "Email LIKE '%@%'");
                op.HasCheckConstraint(
                    "CK_User_Phone",
    "PhoneNumber IS NOT NULL AND LEN(PhoneNumber) = 11 AND PhoneNumber LIKE '01[0-9]%'"
                );
            });

        }
    }
}
