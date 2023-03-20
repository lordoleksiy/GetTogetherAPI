namespace GetTogether.DAL.Entities;

public class User: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string? Description { get; set; }
    public ICollection<User>? Followers { get; set; }
    public ICollection<User>? Following { get; set; }
    public ICollection<ChatGroup>? Groups { get; set; }
}
