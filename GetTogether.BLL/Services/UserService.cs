using AutoMapper;
using EasySpeak.Core.BLL.Services;
using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.User;
using GetTogether.DAL.Context;
using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.BLL.Services;

public class UserService : BaseService, IUserService
{
    public UserService(DataContext context, IMapper mapper) : base(context, mapper)
    {}

    public async Task<ICollection<UserDTO>> GetAll() => _mapper.Map<List<User>, ICollection<UserDTO>>(await _context.Users.ToListAsync());

    public async Task<UserDTO> GetById(int id) => _mapper.Map<UserDTO>(await _context.Users.FindAsync(id));

    public async Task<UserDTO> Post(NewUserDTO userDTO)
    {
        var user = _mapper.Map<User>(userDTO);
        user.Login = GenerateLogin();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(user);
    }

    private string GenerateLogin()
    {
        return "user" + Guid.NewGuid().ToString("N").Substring(0, 5);
    }
}
