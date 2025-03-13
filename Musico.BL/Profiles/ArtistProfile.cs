using AutoMapper;
using Musico.BL.DTOs;
using Musico.Core.Entities;

namespace Musico.BL.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistGetDto>()
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(src => src.Albums));

            CreateMap<ArtistCreateDto, Artist>();
        }
    }
}
