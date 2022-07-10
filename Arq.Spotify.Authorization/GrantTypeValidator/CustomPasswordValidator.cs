using System.Threading;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Validation;

namespace Arq.Spotify.Authorization.GrantTypeValidator
{
    public class CustomPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var user = context.UserName;

            if (user == "admin" && password == "1234")
            {
                context.Result = new GrantValidationResult("1234", OidcConstants.AuthenticationMethods.Password);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
