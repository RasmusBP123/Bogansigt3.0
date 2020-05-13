using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAnsigt.Models;
using Bogansigt3._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bogansigt3._0.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var result = await _authenticationService.CreateUser(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = await _authenticationService.Login(user, user.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            { 
                return View("Login");
            }
            return Ok();

        }

        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}