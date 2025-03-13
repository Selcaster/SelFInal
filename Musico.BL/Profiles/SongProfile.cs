using AutoMapper;
using Musico.BL.DTOs;
using Musico.Core.Entities;

namespace Musico.BL.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongGetDto>()
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album));

            CreateMap<SongCreateDto, Song>();
        }
    }
}
