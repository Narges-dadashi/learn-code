namespace api.DTOs;

public static class Mappers
{
    public static AppUser ConvertRegisterDtoToAppUser(RegisterDto registerDto)
    {
        return new AppUser
        {
            Email = registerDto.Email.Trim().ToLowerInvariant(),
            Password = registerDto.Password,
            ConfirmPassword = registerDto.ConfirmPassword,
            DateOfBirth = registerDto.DateOfBirth
        };
    }

    public static LoggedInDto ConvertAppUserToLoggedInDto(AppUser appUser, string tokenValue)
    {
        return new LoggedInDto
        {
            Email = appUser.Email,
            Name = appUser.Name,
            Token = tokenValue
        };
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