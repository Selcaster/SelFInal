using AutoMapper;
using Musico.BL.DTOs;
using Musico.BL.DTOs.UserDtos;
using Musico.BL.Helpers;
using Musico.Core.Entities;

namespace Musico.BL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>()
           .ForMember(x => x.PasswordHash, opt => opt.MapFrom(y => HashHelper.HashPassword(y.Password)));
            CreateMap<User, UserGetDto>();
        }
    }
}
