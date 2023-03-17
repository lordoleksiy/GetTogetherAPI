using GetTogether.DAL.Entities;
using GetTogether.DAL.Context.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.DAL;

public class DataContext: DbContext
{
    public DbSet<UserProfile> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<ChatGroup> ChatGroups { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new ChatConfiguration());
        modelBuilder.ApplyConfiguration(new MessageConfiguration());


        base.OnModelCreating(modelBuilder);
    }
}