namespace api.Extensions;

public static class RepositoryServiceExtensions
{
     public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();

        return services;
    }
}