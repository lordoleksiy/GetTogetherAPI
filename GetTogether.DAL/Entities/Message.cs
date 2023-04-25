namespace GetTogether.DAL.Entities;

public class Message: IEntity<long>
{
    public long Id { get; set; }
    public string text { get; set; }
    public long ChatId { get; set; }
    public ChatGroup ChatGroup { get; set; }
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public long? RepliedPersonId { get; set; }
    public User? RepliedPerson { get; set; }
}
