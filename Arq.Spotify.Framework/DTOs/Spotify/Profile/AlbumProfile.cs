using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Framework.DTOs.Spotify.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {

        public AlbumProfile()
        {
            CreateMap<Album, AlbumInputDTO>()
                .ForMember(x => x.Band, f => f.MapFrom(m => m.Band.Name));
        }
    }
}
