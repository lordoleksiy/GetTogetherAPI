using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name).IsRequired();
        builder.HasIndex(u => u.Login).IsUnique(true);
        builder.HasIndex(u => u.Email).IsUnique(true);

        builder
            .HasMany(u => u.Followers)
            .WithMany(u => u.Following)
            .UsingEntity<object>(
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("FollowerId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("UserId", "FollowerId");
                    j.ToTable("Following");
                });
        builder.HasOne(u => u.ImageAvatar)
            .WithOne()
            .HasForeignKey<User>(u => u.ImageId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
