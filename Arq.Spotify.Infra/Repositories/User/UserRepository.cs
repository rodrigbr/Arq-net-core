using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Infra.Context;

namespace Arq.Spotify.Infra.Repositories.User
{
    public class UserRepository : RepositoryBase<Domain.Entities.User.User>, IUserRepository
    {
        public UserRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
