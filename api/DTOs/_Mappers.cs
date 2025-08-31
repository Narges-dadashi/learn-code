namespace api.DTOs;

public static class Mappers
{
    public static AppUser ConvertRegisterDtoToAppUser(RegisterDto registerDto)
    {
        return new AppUser(
            Id: null,
            Email: registerDto.Email,
            Password: registerDto.Password,
            ConfirmPassword: registerDto.ConfirmPassword,
            DateOfBirth: registerDto.DateOfBirth,
            Name: "",
            Gender: "",
            Country: ""
        );
    }
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