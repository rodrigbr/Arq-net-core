using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace Arq.Spotify.Authorization.ProfileService
{
    public class UserProfile : IProfileService
    {
        public UserProfile(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; set; }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();
            var user = await this.Repository.GetById(Guid.Parse(id));

            var Claims = new List<Claim>()
            {
                new Claim("name", user.Name),
                new Claim("email", user.Email.Value),
                new Claim("role", "spotify-user"),
            };

            context.IssuedClaims = Claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
