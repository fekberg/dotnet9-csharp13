using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
public class UserController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return Ok();
    }
}