using Microsoft.AspNetCore.Mvc;
using SnykCodeLab.Security;

namespace SnykCodeLab.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly LegacyCredentialService _credentials;
    public AuthController(LegacyCredentialService credentials) => _credentials = credentials;

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if (!_credentials.Validate(request.Username, request.Password))
            return Unauthorized();

        // LAB VULNERABILITY: returns a fixed secret as if it were an access token.
        return Ok(new { token = _credentials.GetSecretForLegacyIntegration(), username = request.Username });
    }

    [HttpPost("reset-token")]
    public IActionResult ResetToken([FromQuery] string username)
    {
        // LAB VULNERABILITY: no identity verification or rate limiting; token is predictable.
        return Ok(new { username, resetToken = LegacyCredentialService.CreateResetToken() });
    }
}

public sealed class LoginRequest
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}
