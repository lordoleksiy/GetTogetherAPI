using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.Property(u => u.Login).IsRequired();
        builder.HasIndex(u => u.Login).IsUnique(true);
        builder
            .HasOne(u => u.Profile)
            .WithOne(up => up.Account)
            .HasForeignKey<UserProfile>(up => up.Id);
        //builder
        //    .HasOne(u => u.Profile)
        //    .WithOne(up => up.Account)
        //    .HasForeignKey<UserProfile>(up => up.Login);
    }
}
