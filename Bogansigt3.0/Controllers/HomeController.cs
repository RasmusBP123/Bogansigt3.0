using BogAnsigt.Models;
using BogAnsigt.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BogAnsigt.Models.Viewmodel;

namespace BogAnsigt.Controllers
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
            return View(await GetFriends());
        }
        public async Task<IActionResult> People()
        {
            var friends = await GetFriends();
            var people = await _dbContext.Users.ToListAsync();
            var peopleVM = new List<People>();
            people.ForEach(x => peopleVM.Add(new People { Id = x.Id, Name = x.UserName, PhoneNumber = x.PhoneNumber, Friend = friends.Contains(x) }));
            return View(peopleVM);
        }
        public async Task<IActionResult> FriendToggle(string friendId, string refferer)
        {
            var curUserId = _userManager.GetUserId(HttpContext.User);
            var curUser = _dbContext.Users.Include(x => x.Friends).FirstOrDefault(x => x.Id == curUserId);
            if (curUser == null) return NotFound();
            var actualFriend = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == friendId);
            if (actualFriend == null) return NotFound();
            var friend = new UserFriend { Friend = actualFriend, FriendId = actualFriend.Id, User = curUser, UserId = curUserId };
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
        private async Task<List<User>> GetFriends()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var user = await _dbContext.Users.Include(user => user.Friends).ThenInclude(x => x.Friend).FirstOrDefaultAsync(x => x.Id == currentUserId);
            var friends = new List<User>();
            user.Friends.ForEach(x => friends.Add(x.Friend));
            return friends;
        }
    }
}
