using Musico.BL.DTOs;

namespace Musico.BL.ExternalServices.Interfaces;

public interface ICurrentUser
{
    int GetId();
    string GetUserName();
    string GetEmail();
    int GetRole();
    Task<UserGetDto> GetUserAsync();
}
