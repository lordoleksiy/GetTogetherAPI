namespace GetTogether.DAL.Entities;

public class User: IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Followers { get; set; }
    public ICollection<User> Following { get; set; }
    public ICollection<ChatGroup> Groups { get; set; }
    public ICollection<Party> CreatedParties { get; set; }
    public ICollection<Party> VisitedParties { get; set; }
    public long? ImageId { get; set; }
    public Image? ImageAvatar { get; set; }

    public User()
    {
        Followers = new List<User>();
        Following = new List<User>();
        Groups = new List<ChatGroup>();
        CreatedParties = new List<Party>();
        VisitedParties = new List<Party>();
    }
}
