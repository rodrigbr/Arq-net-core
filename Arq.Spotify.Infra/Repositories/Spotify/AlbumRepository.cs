using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Domain.Entities.Spotify;
using Arq.Spotify.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Arq.Spotify.Infra.Repositories.Spotify
{
    public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Album>> getAllAlbum()
        {
            return await Task.FromResult(Context.Set<Album>().Include(x=> x.Musics).AsEnumerable());
        }
    }
}
