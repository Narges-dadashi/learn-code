namespace api.Interfaces;

public interface IAdminRepository
{
    public Task<DeleteResult?> DeleteUserAsync(string targetUserName, CancellationToken cancellationToken);
}