using api.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers;

[Authorize(Policy = "RequiredAdminRole")]
public class AdminController(IAdminRepository _adminRepository) : BaseApiController
{
    [HttpDelete("delete-user/{targetUserName}")]
    public async Task<ActionResult<Response>> DeleteUser(string targetUserName, CancellationToken cancellationToken)
    {
        string? userId = User.GetUserId();

        if (userId is null) return Unauthorized();

        DeleteResult? deleteResult = await _adminRepository.DeleteUserAsync(targetUserName, cancellationToken);

        return deleteResult is null
            ? BadRequest("Delete user failed try again")
            : Ok(new Response(Message: "User deleted successfully"));
    }
}