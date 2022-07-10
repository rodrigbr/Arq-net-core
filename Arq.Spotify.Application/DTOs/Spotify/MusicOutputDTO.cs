using System;

namespace Arq.Spotify.Application.DTOs.Spotify
{
    public class MusicOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
    }
}
