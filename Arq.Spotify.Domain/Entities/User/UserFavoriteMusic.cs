using System;
using Arq.Spotify.Domain.Entities.Spotify;

namespace Arq.Spotify.Domain.Entities.User
{
    public class UserFavoriteMusic
    {
        public Guid Id { get; set; }

        public virtual Music Music { get; set; }

        public virtual User User { get; set; }
    }
}
