using HabitTracker.Models;
using HabitTracker.Models.Entites;
using HabitTracker.Models.ViewModels;
using HabitTracker.Repos.Implementation;
using HabitTracker.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Controllers
{
    public class HabitController : Controller
    {
        private readonly IHabitRepo _habitRepo;
        private readonly IUserRepo _userRepo;
        private readonly ICategorey categoryRepo;

        public HabitController(IHabitRepo habitRepo,IUserRepo userRepo, AppDbContext appDbContext,ICategorey categoryRepo)
        {
            _habitRepo = habitRepo;
            _userRepo = userRepo;
            this.categoryRepo = categoryRepo;
            //   _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Habit>> GetHabitByUserId(int id)
        {
            return await _habitRepo.GetHabitByUserId(id);
        }
        public async Task<IActionResult> GetAllHabits()
        {
            var habits = await _habitRepo.GetAllHabits();
            return View(habits);
        }
        public async Task<IActionResult> Create()
        {
            var user = await _userRepo.GetAllUsers();
            var category =  await categoryRepo.GetAllCategories();

            HabitViewModel habitViewModel = new HabitViewModel()
            {
                users = user,
                Category = category
            };
            return View(habitViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(HabitViewModel habit)
        {
            if(habit != null)
            {
            await _habitRepo.CreateHabit(habit);
            return RedirectToAction("GetAllHabits");
            }
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var user = await _userRepo.GetById(id);
        //    return View(user);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> Delete(Habit habit)
        //{
        //    if (habit == null) return View();
        //    await _habitRepo.DeleteHabit(habit);
        //    return RedirectToAction("GetAllHabits");
        //}
        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var user = await _habitRepo.GetHabitByUserId(id);
        //    return View(user);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(HabitViewModel habitViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var habit = new Habit
        //        {
        //            Name = habitViewModel.Name,
        //            UserId = habitViewModel.Userid,
        //            CatId = habitViewModel.Catid,
        //        };
        //        await _habitRepo.UpdateHabit(habitViewModel);
        //        return RedirectToAction("GetAllHabits");
        //    }

        //    var users = await _userRepo.GetAllUsers();
        //    var categories = await categoryRepo.GetAllCategories();

        //    habitViewModel.users = users;
        //    habitViewModel.Category = categories;

        //    return View(habitViewModel);
       // }

    }
}
