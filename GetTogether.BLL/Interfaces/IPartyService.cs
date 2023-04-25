using GetTogether.Common.DTO.Party;

namespace GetTogether.BLL.Interfaces;

public interface IPartyService
{
    public Task<ICollection<PartyDTO>> GetActiveParties();
    public Task<PartyDTO> GetById(long id);
}
