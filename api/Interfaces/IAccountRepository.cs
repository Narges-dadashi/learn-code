namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> RegisterAsync(AppUser appUser, CancellationToken cancellationToken);
    // public Task<LoggedInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);
}