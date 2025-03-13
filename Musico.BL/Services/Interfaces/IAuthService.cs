using Musico.BL.DTOs.UserDtos;

namespace Musico.BL.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}