using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServer2Test.InternalClasses
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResource
                {
                    Name = "rple",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                //new ApiResource
                //{
                //    Name = "customAPI",
                //    DisplayName = "Custom API",
                //    Description = "Custom API Access",
                //    UserClaims = new List<string> {"role"},
                //    ApiSecrets = new List<Secret> {new Secret("scopeSecret".Sha256())},
                //    Scopes = new List<Scope> {
                //        new Scope("customAPI.read"),
                //        new Scope("customAPI.write")
                //    }
                //}
                new ApiResource("default-api", "Default (all) API")
            };
        }
    }
}
