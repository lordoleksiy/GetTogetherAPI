using AutoMapper;
using EasySpeak.Core.BLL.Services;
using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO;
using GetTogether.Common.DTO.User;
using GetTogether.DAL.Context;
using GetTogether.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.BLL.Services;

public class UserService : BaseService, IUserService
{
    private IAccountService _accountService;
    public UserService(DataContext context, IMapper mapper, IAccountService accountService) : base(context, mapper)
    {
        _accountService = accountService;
    }

    public async Task<ICollection<UserDTO>> GetAll() => _mapper.Map<List<User>, ICollection<UserDTO>>(await _context.Users.ToListAsync());

    public async Task<UserDTO> GetUser()
    {
        var user = await _context.Users.FindAsync(_accountService.UserId)
             ?? throw new ArgumentException($"Failed to find the user");

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> CreateUser(NewUserDTO userDTO)
    {
        var user = _mapper.Map<User>(userDTO);
        user.Login = GenerateLogin();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> UpdateUser(UserDTO userDTO)
    {
        var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == _accountService.UserId) 
            ?? throw new ArgumentException($"Failed to find the user with id {_accountService.UserId}");

        _mapper.Map<UserDTO, User>(userDTO, user);
        await _context.SaveChangesAsync();
        return _mapper.Map<User, UserDTO>(user);
    }

    public async Task<UserDTO> DeleteUser()
    {
        var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == _accountService.UserId)
            ?? throw new ArgumentException($"Failed to find the user with id {_accountService.UserId}");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(user);
    }

    private string GenerateLogin()
    {
        return "user" + Guid.NewGuid().ToString("N")[..5];
    }

    public Task<UserDTO> GetFilteredUser(UserFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email)
            ?? throw new ArgumentException($"Failed to find the user with email {email}");

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> GetByLogin(string login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login)
            ?? throw new ArgumentException($"Failed to find the user with login {login}");

        return _mapper.Map<UserDTO>(user);
    }
}
