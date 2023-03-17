using GetTogether.DAL.Interfaces;

namespace GetTogether.DAL.Entities;

public class UserProfile: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string? Description { get; set; }
    public IEnumerable<UserProfile>? Followers { get; set; }
    public IEnumerable<UserProfile>? Following { get; set; }
    public IEnumerable<ChatGroup>? Groups { get; set; }
    public UserAccount Account { get; set; }
}
