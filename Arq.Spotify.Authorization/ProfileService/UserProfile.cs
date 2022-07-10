using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace Arq.Spotify.Authorization.ProfileService
{
    public class UserProfile : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var Claims = new List<Claim>()
            {
                new Claim("name", "LoremIpsumUser"),
                new Claim("email", "xpto@xpto.com"),
                new Claim("role", "spotify-user"),
            };

            context.IssuedClaims = Claims;
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
