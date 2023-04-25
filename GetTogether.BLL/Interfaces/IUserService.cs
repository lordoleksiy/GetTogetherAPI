using GetTogether.Common.DTO;
using GetTogether.Common.DTO.User;

namespace GetTogether.BLL.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDTO>> GetAll();
    Task<UserDTO> GetUser();
    Task<UserDTO> CreateUser(NewUserDTO userDTO);
    Task<UserDTO> UpdateUser(UserDTO userDTO);
    Task<UserDTO> DeleteUser();
    Task<UserDTO> GetFilteredUser(UserFilter filter);
}
