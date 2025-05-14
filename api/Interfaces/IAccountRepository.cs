using api.Models;

namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<AppUser?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken);
    public Task<List<AppUser?>> GetAllAsync(CancellationToken cancellationToken);
}