using GetTogether.BLL.Interfaces;
using GetTogether.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace GetTogether.BLL.Services;

public class AccountService : IAccountService
{
    private readonly DataContext _context;
    public AccountService(DataContext dataContext)
    {
        _context = dataContext;
    }
    public long UserId { get; private set; }

    public async Task SetUserId(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
        {
            UserId = user.Id;
        }
    }
}
