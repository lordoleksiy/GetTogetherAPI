using AutoMapper;
using GetTogether.Common.DTO.User;
using GetTogether.DAL.Entities;

namespace GetTogether.BLL.MappingProfiles;

public class UserProfile: Profile
{
    public UserProfile() 
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
