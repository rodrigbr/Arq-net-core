using System.Collections.Generic;

namespace Arq.Spotify.Application.DTOs.Spotify
{
    public class AlbumInputDTO
    {
        public string Name { get; set; }
        public string Band { get; set; }
        public string Description { get; set; }
        public string Backdrop { get; set; }
        public List<MusicInputDTO> Musics { get; set; }
    }
}
