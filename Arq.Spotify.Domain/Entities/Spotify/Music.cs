using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.ValueObjects.Music;

namespace Arq.Spotify.Domain.Entities.Spotify
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Duration Duration { get; set; }
    }
}
