using System.Collections;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Arq.Spotify.Authorization.IdentityServerConfiguration
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("SpotifyLite", "Infnet Arquitetura", new string[] { "user", "admin" })
                {
                    ApiSecrets =
                    {
                        new Secret("SuperSenhaDificil".Sha256())
                    },
                    Scopes =
                    {
                        "SpotifyLite-API"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope
                {
                    Name = "SpotifyAPI",
                    Description = "Scope for API Spotify",
                    UserClaims = {"spotify-user", "spotify-admin"}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId = "f19c4442-48e7-4d56-ad1e-bb5ae56122e4",
                    ClientName = "Spotify Service Token",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {new Secret("SpotifySecret".Sha256())},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotifyAPI"
                    }
                }
            };
        }
    }
}
