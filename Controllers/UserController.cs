using HabitTracker.Models;
using HabitTracker.Models.Entites;
using HabitTracker.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _userRepo;
        //private readonly AppDbContext appDbContext;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
           // this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsers();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (user == null)
            {
                return View();
            }
            await _userRepo.AddUser(user);
            return RedirectToAction("GetAllUsers");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user =await _userRepo.GetUserWithHabitList(id);
            return View(user);
        }







































        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepo.GetById(id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(User user)
        {
            if (user == null) return View();
            await _userRepo.DeleteUser(user);
            return RedirectToAction("GetAllUsers");
        }

        //public async Task<IActionResult> GetAllUsers()
        //{

        //    var users = await _userRepo.GetAllUsers();
        //    return View(users);
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(User user)
        //{
        //    if (user != null)
        //    {
        //        await _userRepo.AddUser(user);
        //        return RedirectToAction("GetAllUsers");
        //    }
        //    return View();
        //}



        //public async Task<IActionResult> Details(int id)
        //{
        //    var user = await _userRepo.GetUserWithHabitList(id);

        //    return View(user);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var user = await _userRepo.GetById(id);
        //    if (user != null)
        //    {
        //        return View(user);
        //    }
        //    return RedirectToAction("GetAllUsers");
        //}
        //[HttpPost , ActionName("Delete")]
        //public async Task<IActionResult> Delete(User user)
        //{
        //    await _userRepo.DeleteUser(user);
        //    return RedirectToAction("GetAllUsers");
        //}

    }
}
