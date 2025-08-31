namespace api.Interfaces;

public interface IAccountRepository
{
    public Task<LoggedInDto?> RegisterAsync(RegisterDto userInput, CancellationToken cancellationToken);
    public Task<LoggedInDto?> LoginAsync(LoginDto userInput, CancellationToken cancellationToken);
    public Task<DeleteResult?> DeleteByIdAsync(string userId, CancellationToken cancellationToken);
}