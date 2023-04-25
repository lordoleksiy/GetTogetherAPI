using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(m => m.ChatId).IsRequired();
        builder.Property(m => m.AuthorId).IsRequired();
        builder
            .HasOne(m => m.Author)
            .WithOne()
            .HasForeignKey<Message>(m => m.AuthorId);

        builder
            .HasOne(m => m.RepliedPerson)
            .WithOne()
            .HasForeignKey<Message>(m => m.RepliedPersonId);
            

    }
}
