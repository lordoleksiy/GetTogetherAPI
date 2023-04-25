using AutoMapper;
using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.Party;
using GetTogether.DAL.Context;
using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.BLL.Services;

public class PartyService : BaseService, IPartyService
{
    public PartyService(DataContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<ICollection<PartyDTO>> GetActiveParties()
    {
        var parties = await _context.Parties.Where(u => u.Status == Common.Enums.Status.InProgress).ToListAsync();
        return _mapper.Map<ICollection<Party>, ICollection<PartyDTO>>(parties);
    }

    public async Task<PartyDTO> GetById(long id)
    {
        var party = await _context.Parties.FindAsync(id);
        return _mapper.Map<PartyDTO>(party);
    }
}
