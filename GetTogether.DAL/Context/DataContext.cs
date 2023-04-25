using GetTogether.DAL.Entities;
using GetTogether.DAL.Context.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.DAL.Context;

public class DataContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<ChatGroup> ChatGroups { get; set; }
    public DbSet<Party> Parties { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ChatConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new PartyConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}