using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using IdentityModel;
using IdentityServer4.Test;
using TestProject.Authorization.Users;

namespace IdentityServer2Test.InternalClasses
{
    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
        //public static List<User> Get()
        //{
        //    return new List<User> {
        //        new User {

        //            Id = Convert.ToInt64("34"),
        //            UserName = "dejan",
        //            Password = "123456",
        //            Claims = new List<UserClaim>
        //            {
        //                new UserClaim()
        //            }
        //        }
        //    };
        //}

    }
}
