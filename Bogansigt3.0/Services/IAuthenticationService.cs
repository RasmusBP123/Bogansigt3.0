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
        Task<IdentityResult> CreateUser(User user);
        Task<IdentityResult> ForgotPassword(User user, string password, string newPassword);
    }
}
