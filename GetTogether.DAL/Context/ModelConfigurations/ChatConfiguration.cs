using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class ChatConfiguration : IEntityTypeConfiguration<ChatGroup>
{
    public void Configure(EntityTypeBuilder<ChatGroup> builder)
    {
        builder
        .HasMany(c => c.Users)
        .WithMany(u => u.Groups)
        .UsingEntity<object>(
            j => j
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade),
            j => j
                .HasOne<ChatGroup>()
                .WithMany()
                .HasForeignKey("GroupId")
                .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("GroupId", "UserId");
                j.ToTable("ChatGroupsUsers");
            }
        );
        builder
            .HasOne(a => a.Creator)
            .WithMany()
            .HasForeignKey(a => a.CreatorId);

        builder
            .HasMany(m => m.Messages)
            .WithOne(c => c.ChatGroup)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
