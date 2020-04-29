using BogAnsigt.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bogansigt3._0.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateRole(User user);
    }
}
