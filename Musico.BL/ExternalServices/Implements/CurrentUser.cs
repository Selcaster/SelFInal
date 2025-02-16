using AutoMapper;
using Musico.BL.Constants;
using Musico.BL.DTOs;
using Musico.BL.Exceptions.Common;
using Musico.BL.ExternalServices.Interfaces;
using Musico.Core.Entities;
using Musico.Core.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Musico.BL.ExternalServices.Implements
{
    public class CurrentUser(IHttpContextAccessor _httpContext,
        IUserRepository _repo,
        IMapper _mapper) : ICurrentUser
    {
        ClaimsPrincipal? User = _httpContext.HttpContext?.User;
        public string GetEmail()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Email)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return value;
        }


        public int GetId()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Id)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return Convert.ToInt32(value);
        }

        public int GetRole()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Role)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return Convert.ToInt32(value);
        }

        public async Task<UserGetDto> GetUserAsync()
        {
            int userId = GetId();
            var user = await _repo.GetByIdAsync(userId);
            return _mapper.Map<UserGetDto>(user);
        }

        public string GetUserName()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Username)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return value;
        }
    }
}
