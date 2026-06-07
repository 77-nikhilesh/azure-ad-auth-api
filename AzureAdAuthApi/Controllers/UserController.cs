using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureAdAuthApi.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        // To see all details from claims

        //  var profile = User.Claims
        // .Select(user => new
        // {
        //     user.Type,
        //     user.Value
        // });


        // To show only required details
        var profile = new
        {
            ObjectId= User.FindFirst("oid")?.Value,
            Name= User.FindFirst("name")?.Value,
            Email= User.FindFirst("preferred_username")?.Value
        };

        return Ok(profile);
    }
}
