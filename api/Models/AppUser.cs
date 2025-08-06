namespace api.Models;

public record AppUser(
[EmailAddress] string Email,
string Name,
string Password,
string ConfirmPassword,
DateOnly DateOfBirth,
string Gender,
string Country
);