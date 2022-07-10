using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
