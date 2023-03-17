using GetTogether.DAL.Interfaces;

namespace GetTogether.DAL.Entities;

public class ChatGroup: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<UserProfile> Users { get; set; }
    public int CreatorId { get; set; }
    public UserProfile Creator { get; set; }
    public IEnumerable<Message>? Messages { get; set; }
}
