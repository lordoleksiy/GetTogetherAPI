namespace GetTogether.DAL.Entities;

public class Image : IEntity<long>
{
    public long Id { get; set; }
    public string Url { get; set; }
}
