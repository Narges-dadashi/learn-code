namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IAccountRepository accountRepository) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(AppUser userInput, CancellationToken cancellationToken)
    {
        AppUser? user = await accountRepository.RegisterAsync(userInput, cancellationToken);

        if (user is null)
        {
            return BadRequest("This email is already taken");
        }

        return Ok(user);
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<AppUser>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser>? appUsers = await accountRepository.GetAllAsync(cancellationToken);

        if (appUsers is null)
            return NoContent();

        return appUsers;
    }
}