using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Domain.Entities.Spotify;
using Arq.Spotify.Infra.Context;

namespace Arq.Spotify.Infra.Repositories.Spotify
{
    public class MusicRepository : RepositoryBase<Music>, IMusicRepository
    {
        public MusicRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
