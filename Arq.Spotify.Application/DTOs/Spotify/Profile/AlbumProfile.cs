using Arq.Spotify.Domain.Entities.Spotify;

namespace Arq.Spotify.Application.DTOs.Spotify.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {

        public AlbumProfile()
        {
            CreateMap<Album, AlbumOutputDTO>()
                .ForMember(x => x.Band, f => f.MapFrom(m => m.Band.Name));
            CreateMap<AlbumInputDTO, Album>()
                .ForMember(x => x.Band.Name, f => f.MapFrom(m => m.Band));
            CreateMap<Music, MusicOutputDTO>()
                .ForMember(x => x.Duration, f => f.MapFrom(m => m.Duration.FormatValue));
            CreateMap<MusicInputDTO, Music>()
                .ForMember(x => x.Duration.Value, f => f.MapFrom(m => m.Duration));

        }
    }
}
