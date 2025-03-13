using Musico.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Musico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IEmailService _service):ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> SendEmail()
    {
        await _service.SendEmailConfirmation();
        return Content("Email sended"); 
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> VerifyAccount(string token)
    {
        await _service.AccountVerify(token);
        return Content("Email confirmed"); 
    }
}