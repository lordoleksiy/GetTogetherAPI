using GetTogether.Common.Enums;

namespace GetTogether.DAL.Entities;

public class Party: IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Organizers { get; set; }
    public ICollection<User> Users { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Status Status { get; set; }
    public Privacy Privacy { get; set; }
    public Party()
    {
        Organizers = new List<User>();
        Users = new List<User>();
    }
}
