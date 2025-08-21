namespace api.Interfaces;

public interface IUserRepository
{
    public Task<AppUser?> GetByIdAsync(string userId, CancellationToken cancellationToken);
    public Task<MemberDto?> UpdateByIdAsync(string userId, AppUser userInput, CancellationToken cancellationToken);
}