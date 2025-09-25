namespace api.Controllers;

[Authorize]
public class UserController(IUserRepository userRepository) : BaseApiController
{
    [HttpPut("update/{userId}")]
    public async Task<ActionResult<MemberDto>> UpdateById(string userId, AppUser userInput, CancellationToken cancellationToken)
    {
        MemberDto? memberDto = await userRepository.UpdateByIdAsync(userId, userInput, cancellationToken);

        if (memberDto is null)
            return BadRequest("You are not logged. Please Logged in again!");

        return memberDto;
    }
}