using System;
using System.Collections.Generic;

namespace Arq.Spotify.Application.DTOs.Spotify
{
    public class AlbumOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Band { get; set; }
        public string Description { get; set; }
        public string Backdrop { get; set; }
        public List<MusicOutputDTO> Musics { get; set; }
    }
}
