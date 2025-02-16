using System.Security.Claims;
using Musico.Core.Entities;

namespace Musico.BL.ExternalServices.Interfaces;

public interface IJwtTokenHandler
{
    string CreateToken(User user,int hours);
}