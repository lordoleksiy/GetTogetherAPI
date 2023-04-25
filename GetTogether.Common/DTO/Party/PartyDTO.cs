using GetTogether.Common.DTO.User;
using GetTogether.Common.Enums;

namespace GetTogether.Common.DTO.Party;

public class PartyDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<UserDTO> Organizers { get; set; }
    public ICollection<UserDTO> Users { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; }
    public string Privacy { get; set; }
}
