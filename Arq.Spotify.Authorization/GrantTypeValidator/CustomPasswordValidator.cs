using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Domain.Entities.User;
using IdentityModel;
using IdentityServer4.Validation;

namespace Arq.Spotify.Authorization.GrantTypeValidator
{
    public class CustomPasswordValidator : IResourceOwnerPasswordValidator
    {
        public CustomPasswordValidator(IUserRepository repository)
        {
            Repository = repository;
        }

        public IUserRepository Repository { get; set; }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var username = context.UserName;

            var user = await this.Repository.FindOneByCriteria<User>(x => x.Email.Value == username && x.Password.Value == password);

            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);

            }
        }
    }
}
