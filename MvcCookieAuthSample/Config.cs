using System.Collections;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace MvcCookieAuthSample
{
    public class Config
    {
        public static IEnumerable<Client> GetClient(){
            return new List<Client>{
                new Client(){
                    ClientId = "mvc",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    ClientSecrets = {new Secret("secret".Sha256())},
                    RequireConsent = true,
                    RedirectUris = {"http://localhost:5001/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:5001/signout-callback-oidc"},
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    ClientName = "Mvc Client",
                    ClientUri="http://localhost:5001",
                    LogoUri="https://stackify.com/wp-content/uploads/2017/10/NET-core-2.1-1-793x397.png",
                    AllowRememberConsent=true,
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources(){
            return new List<ApiResource>
            {
                new ApiResource("api", "My API Application!")
   };
        }

        public static List<TestUser> GetTestUsers()
        {
           return new List<TestUser>{
               new TestUser{
                SubjectId = "10000",
                Username = "leo111",
                Password = "111111"
               }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>{
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
    }
}