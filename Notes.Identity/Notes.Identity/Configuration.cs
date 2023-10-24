using IdentityModel;

using IdentityServer4;
using IdentityServer4.Models;

using System.Collections.Generic;
using System.Security.Claims;

namespace Notes.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NotesWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResource("openid", new [] { ClaimTypes.NameIdentifier }),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebAPI", "Web API")
                {
                    Scopes = {"NotesWebAPI"},
                    UserClaims = { ClaimTypes.NameIdentifier, JwtClaimTypes.Name }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "notes-web-api",
                    ClientName = "Notes Web",
                    AllowedGrantTypes = { GrantType.ClientCredentials },
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris  =
                    {
                        "http://localhost:3000/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3000/singout-oidc"
                    },
                    AllowedScopes = { "NotesWebAPI" },
                    AllowAccessTokensViaBrowser = true,


                }
            };
    }
}
