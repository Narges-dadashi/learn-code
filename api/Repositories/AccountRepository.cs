namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    #region Mongodb
    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    #endregion

    public async Task<LoggedInDto?> RegisterAsync(AppUser userInput, CancellationToken cancellationToken)
    {
        AppUser user = await _collection.Find<AppUser>(doc =>
            doc.Email == userInput.Email).FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
            return null;

        await _collection.InsertOneAsync(userInput, null, cancellationToken);

        return Mappers.ConvertAppUserToLoggedInDto(userInput);
    }
}