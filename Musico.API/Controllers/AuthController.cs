using System.Security.Claims;
using Musico.BL.DTOs.UserDtos;
using Musico.BL.Services;
using Musico.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Musico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService _service):ControllerBase
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _service.RegisterAsync(dto);
        return Created();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok(await _service.LoginAsync(dto));
    }
}