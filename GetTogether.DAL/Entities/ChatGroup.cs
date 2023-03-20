namespace GetTogether.DAL.Entities;

public class ChatGroup: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; }
    public int CreatorId { get; set; }
    public User Creator { get; set; }
    public ICollection<Message>? Messages { get; set; }
}
