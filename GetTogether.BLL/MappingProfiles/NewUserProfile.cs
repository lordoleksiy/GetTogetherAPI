using AutoMapper;
using GetTogether.Common.DTO.User;
using GetTogether.DAL.Entities;

namespace GetTogether.BLL.MappingProfiles;

public class NewUserProfile: Profile
{
    public NewUserProfile() 
    {
        CreateMap<NewUserDTO, User>();
    }
}
