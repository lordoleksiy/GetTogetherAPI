using AutoMapper;
using GetTogether.Common.DTO.Party;
using GetTogether.DAL.Entities;

namespace GetTogether.BLL.MappingProfiles;

public class PartyProfile: Profile
{
    public PartyProfile()
    {
        CreateMap<Party, PartyDTO>()
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
           .ForMember(dest => dest.Privacy, opt => opt.MapFrom(src => src.Privacy.ToString()))
           .ForMember(dest => dest.Organizers, opt => opt.MapFrom(src => src.Organizers))
           .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users));
    }
}
