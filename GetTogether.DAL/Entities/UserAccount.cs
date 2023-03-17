using GetTogether.DAL.Interfaces;

namespace GetTogether.DAL.Entities;

public class UserAccount:IEntity<int>
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserProfile Profile { get; set; }
}
