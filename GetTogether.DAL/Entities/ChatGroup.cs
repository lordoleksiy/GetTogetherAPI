namespace GetTogether.DAL.Entities;

public class ChatGroup: IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; }
    public long CreatorId { get; set; }
    public User Creator { get; set; }
    public ICollection<Message>? Messages { get; set; }
}
