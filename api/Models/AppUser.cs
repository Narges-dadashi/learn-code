namespace api.Models;

public class AppUser
{
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
    [StringLength(30, MinimumLength = 3)]
    public string Name { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ConfirmPassword { get; init; } = string.Empty;
    public DateOnly DateOfBirth { get; init; }
    public string Gender { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
}