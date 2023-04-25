using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetTogether.DAL.Context.ModelConfigurations;

public class PartyConfiguration : IEntityTypeConfiguration<Party>
{
    public void Configure(EntityTypeBuilder<Party> builder)
    {
        builder
            .HasMany(u => u.Organizers)
            .WithMany(u => u.CreatedParties)
            .UsingEntity<object>(
                j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("OrganizerId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j => j
                    .HasOne<Party>()
                    .WithMany()
                    .HasForeignKey("PartyId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("OrganizerId", "PartyId");
                    j.ToTable("PartyOrganizers");
                });

        builder.HasMany(u => u.Users)
            .WithMany(u => u.VisitedParties)
            .UsingEntity<object>(
             j => j
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j => j
                    .HasOne<Party>()
                    .WithMany()
                    .HasForeignKey("PartyId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("UserId", "PartyId");
                    j.ToTable("PartyVisitors");
                });
    }
}
