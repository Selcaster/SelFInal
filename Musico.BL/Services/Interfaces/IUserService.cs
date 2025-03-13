using Musico.BL.DTOs.UserDtos;
using Musico.Core.Entities;

namespace Musico.BL.Services;

public interface IUserService
{
    Task<string> CreateAsync(RegisterDto dto);
    Task<bool> LoginAsync(LoginDto dto);
    Task DeleteAsync(string username);
}