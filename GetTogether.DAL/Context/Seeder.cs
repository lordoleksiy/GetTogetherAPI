

using Bogus;
using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.DAL.Context;

public static class Seeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var users = GenerateUsers();
        
        modelBuilder.Entity<User>().HasData(users);
    }

    private static IList<User> GenerateUsers(int count = 5)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<User>()
            .RuleFor(u => u.Id, f => f.IndexGlobal)
            .RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Login, f => f.Person.UserName)
            .RuleFor(u => u.Description, f => f.Person.Website)
            .Generate(count);
    }
}
