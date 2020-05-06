using BogAnsigt.Models;
using BogAnsigt.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using Bogansigt3._0.Models.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;
using BogAnsigt.Models.Viewmodel;

namespace BogAnsigt.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbStorage _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(DbStorage dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Pictures()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            if (currentUserId != null)
            {
                var pictures = _dbContext.Picture.Where(p => p.PictureOwner.Id == currentUserId).ToList();
                return View(pictures);
            }
            return View();
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
            var peopleVM = new List<People>();
            if (_signInManager.IsSignedIn(HttpContext.User)) { 
            var friends = await GetFriends();
            var people = await _dbContext.Users.Where(x => x.Id != _userManager.GetUserId(HttpContext.User)).ToListAsync();
            people.ForEach(x => peopleVM.Add(new People { Id = x.Id, Name = x.UserName, PhoneNumber = x.PhoneNumber, Friend = friends.Contains(x) }));
            }
            else
            {
                var people = await _dbContext.Users.ToListAsync();
                people.ForEach(x => peopleVM.Add(new People { Id = x.Id, Name = x.UserName, PhoneNumber = x.PhoneNumber, Friend = true }));
            }
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
            var hest = new UserFriend { User = actualFriend, UserId = actualFriend.Id, Friend = curUser, FriendId = curUserId };
            if (!curUser.Friends.Contains(friend))
            {
                curUser.Friends.Add(friend);
                actualFriend.Friends.Add(hest);
            }
            else
            {
                curUser.Friends.Remove(friend);
                actualFriend.Friends.Remove(hest);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(refferer);
        }
        [HttpPost]
        public async Task<ActionResult> SubmitAsync(IFormFile myFile, List<FrindsToSeePicture> friends)
        {

            var picture = new Picture();
            picture.Id = Guid.NewGuid().ToString();
            using (var memoryStream = new MemoryStream())
            {
                await myFile.CopyToAsync(memoryStream);
                picture.PictureBytes = memoryStream.ToArray();
            }
            picture.PictureOwner = await _userManager.GetUserAsync(HttpContext.User);
            
            _dbContext.Add(picture);
            var allowedFriends =  friends.Where(f => f.CanSeePicture == true).Select(f => f.Friend).ToList();
            foreach (var item in allowedFriends)
            {
                _dbContext.Add(new UserPicture() {Picture = picture, User = item });
            }
            _dbContext.SaveChanges();
            return Redirect("Index");
        }
        public async Task<IActionResult> Upload()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var user = await _dbContext.Users.Include(user => user.Friends).ThenInclude(friend => friend.Friend).FirstOrDefaultAsync(x => x.Id == currentUserId);
            var lis = new List<FrindsToSeePicture>();
            foreach (var item in user.Friends)
            {
                lis.Add(new FrindsToSeePicture() { Friend = item.Friend, CanSeePicture = false });
            }
            return View(lis);
        }
        public async Task<IActionResult> YourPictures()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var pictures = _dbContext.Picture.Where(p => p.PictureOwner.Id == currentUserId);
            return View(pictures);
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
