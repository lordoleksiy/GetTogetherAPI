using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class ProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.Property(u => u.Name).IsRequired();

        builder
            .HasMany(u => u.Followers)
            .WithMany(u => u.Following)
            .UsingEntity<object>(
                j => j
                    .HasOne<UserProfile>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<UserProfile>()
                    .WithMany()
                    .HasForeignKey("FollowerId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("UserId", "FollowerId");
                    j.ToTable("Following");
                });
    }
}
