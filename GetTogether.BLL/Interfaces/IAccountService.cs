namespace GetTogether.BLL.Interfaces;

public interface IAccountService
{
    long UserId { get; }
    Task SetUserId(string email);
}
