using BogAnsigt.Models;
using BogAnsigt.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Bogansigt3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbStorage _dbContext;
        private readonly UserManager<User> _userManager;

        public HomeController(DbStorage dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Friends()
        {
            var currentUserId =  _userManager.GetUserId(HttpContext.User);
            var user = await _dbContext.Users.Include(user => user.Friends).FirstOrDefaultAsync(x => x.Id == currentUserId);
            return View(user.Friends);
        }
        public async Task<IActionResult> People()
        {
            return View( await _dbContext.Users.ToListAsync());
        }
        public async Task<IActionResult> FriendToggle(string friendId, string refferer)
        {
            var curUser = await _userManager.GetUserAsync(HttpContext.User);
            if (curUser == null) return NotFound();
            var friend = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == friendId);
            if (friend == null) return NotFound();
            if (!curUser.Friends.Contains(friend))
            {
                curUser.Friends.Add(friend);
            }
            else
            {
                curUser.Friends.Remove(friend);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(refferer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
