using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetTogether.Common.DTO.User;

namespace GetTogether.BLL.Interfaces;

public interface IUserService
{
    Task<ICollection<UserDTO>> GetAll();
    Task<UserDTO> GetById(int id);
}
