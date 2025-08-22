namespace api.Repositories;

public class MemberRepository : IMemberRepository
{
    #region Mongodb
    private readonly IMongoCollection<AppUser> _collection;

    // Dependency Injection
    public MemberRepository(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    #endregion

    public async Task<IEnumerable<AppUser>?> GetAllAsync(CancellationToken cancellationToken)
    {
        IEnumerable<AppUser> appUsers = await _collection.Find
                (new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Any())
            return null;

        return appUsers;
    }

    public async Task<MemberDto?> GetByUserNameAsync(string Name, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _collection.Find
            (doc => doc.Name == Name).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return null;

        MemberDto memberDto = Mappers.ConvertAppUserToMemberDto(appUser);

        return memberDto;
    }
}