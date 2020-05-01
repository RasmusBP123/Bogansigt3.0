using BogAnsigt.Models;
using BogAnsigt.Storage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bogansigt3._0.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(User user)
        { 
            user.UserName = user.Email;
            user.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "USER");
                if (user.UserName.StartsWith("admin"))
                {
                    await _userManager.AddToRoleAsync(user, "ADMIN");
                }
            }

            return result;
        }

        public async Task<IdentityResult> ForgotPassword(User user, string password, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, password, newPassword);
        }

        public async Task<IList<string>> GetRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<SignInResult> Login(User user, string password)
        {
            var userbyemail = await _userManager.FindByEmailAsync(user.Email);
            var result = await _signInManager.PasswordSignInAsync(userbyemail, password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
