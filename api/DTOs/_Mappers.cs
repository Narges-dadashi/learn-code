namespace api.DTOs;

public static class Mappers
{
    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            Name: appUser.Name
        );
    }

    public static MemberDto ConvertAppUserToMemberDto(AppUser appUser)
    {
        return new(
            Email: appUser.Email,
            Name: appUser.Name,
            Gender: appUser.Gender
        );
    }
}