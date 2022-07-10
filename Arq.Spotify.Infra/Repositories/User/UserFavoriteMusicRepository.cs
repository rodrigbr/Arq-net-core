using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Domain.Entities.User;
using Arq.Spotify.Infra.Context;

namespace Arq.Spotify.Infra.Repositories.User
{
    public class UserFavoriteMusicRepository : RepositoryBase<UserFavoriteMusic>, IUserFavoriteMusicRepository
    {
        public UserFavoriteMusicRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
