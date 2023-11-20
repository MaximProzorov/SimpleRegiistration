using Microsoft.AspNetCore.Mvc;
using SimpleRegistration.Api.Models;
using SimpleRegistration.Api.Repository;

namespace SimpleRegistration.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserRepository userManager, ILogger<UsersController> logger)
    {
        _userRepository = userManager;
        _logger = logger;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        try
        {
            if (await _userRepository.GetUser(model.Login) is not null)
            {
                _logger.LogError($"Register error. Login exists.");
                return BadRequest("Login exists");
            }

            var userId = Guid.NewGuid();
            var rows = await _userRepository.AddUser(new User
            {
                UserId = userId,
                Login = model.Login,
                Password = model.Password
            });

            if (rows == 0)
            {
                _logger.LogError($"Register error. User not created.");
                return StatusCode(500);
            }

            _logger.LogInformation($"Register success.");
            return Ok(new RegisterResponse()
            {
                UserId = userId
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Register error.");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("{userId:guid}/update")]
    public async Task<IActionResult> Update([FromRoute] Guid userId, [FromBody] UpdateModel model)
    {
        try
        {
            var rows = await _userRepository.UpdateUser(userId, model);
            if (rows == 0)
            {
                _logger.LogError($"Update error. User not updated.");
                return StatusCode(500);
            }

            _logger.LogInformation($"Update success.");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Update error.");
            return StatusCode(500, ex.Message);
        }
    }
}
