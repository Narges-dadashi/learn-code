using api.DTOs;

namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> RegisterAsync(AppUser appUser, CancellationToken cancellationToken);
}