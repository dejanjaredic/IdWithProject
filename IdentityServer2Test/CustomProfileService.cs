using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using TestProject.Authorization.Users;

namespace IdentityServer2Test
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager _userManager;

        public CustomProfileService(UserManager userManager)
        {
            _userManager = userManager;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}
