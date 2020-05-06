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
        Task<SignInResult> Login(User user, string password);
        Task Logout();
        Task<IdentityResult> CreateUser(User user);
        Task<IdentityResult> ForgotPassword(User user, string password, string newPassword);
        Task<IList<string>> GetRoles(string email);
    }
}
