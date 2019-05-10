using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer2Test.InternalClasses
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example Client Credentials Client Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("superSecretPassword".Sha256())
                    },
                    AllowedScopes = new List<string> { "customAPI.read" }
                },
                new Client
                {
                    RequireConsent = false,
                    ClientId = "hostClient",
                    ClientName = "Example Implicit Client Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },
                    RedirectUris =  { "https://localhost:21021/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:21021/signout-oidc",
                    PostLogoutRedirectUris =  { "https://localhost:21021/signout-callback-oidc" }



                },
                //new Client  http://localhost:65174
                //{
                //    ClientId = "client",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials.Union(GrantTypes.ResourceOwnerPassword) as ICollection<string>,
                //    AllowedScopes = {"default-api"},
                //    ClientSecrets = {new Secret("secret".Sha256())}
                //}

                new Client
                {
                    RequireConsent = false,
                    ClientId = "hostClient2",
                    ClientName = "Example Implicit Client Application",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "customAPI.write"
                    },
                    RedirectUris =  { "https://localhost:21021/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:21021/signout-oidc",
                    PostLogoutRedirectUris =  { "https://localhost:21021/signout-callback-oidc" }



                }
            };
        }
    }
}
