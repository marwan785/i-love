using HabitTracker.Models;
using HabitTracker.Models.Entites;
using HabitTracker.Models.ViewModels;
using HabitTracker.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Repos.Implementation
{
    public class HabitRepo : IHabitRepo
    {
        private readonly AppDbContext _appDbContext;

        public HabitRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateHabit(HabitViewModel habitVM)
        {
            Habit habit = new Habit()
            {
                Name = habitVM.Name,
                Cdate = habitVM.Hdate,
                UserId = habitVM.Userid,
                CatId = habitVM.Catid
            };
            await _appDbContext.Habits.AddAsync(habit);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Habit>> GetAllHabits()
        {
            var habits = await _appDbContext.Habits
                        .Include(c => c.Category)
                        .Include(u => u.User)
                        .ToListAsync();
            return habits;
        }

        public async Task<IEnumerable<Habit>> GetHabitByUserId(int id)
        {
           var habits = await _appDbContext.Habits.Include(C => C.Category)
                              .Where(U => U.UserId == id).ToListAsync();

            return habits;
        }

        public async Task DeleteHabit(Habit Habit)
        {
            _appDbContext.Habits.Remove(Habit);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateHabit(HabitViewModel habit)
        {
            var existingHabit = await _appDbContext.Habits.FindAsync(habit);
            if (existingHabit != null)
            {
                existingHabit.Name = habit.Name;
                existingHabit.CatId = habit.Catid;
                existingHabit.UserId = habit.Userid;

                _appDbContext.Habits.Update(existingHabit);
                await _appDbContext.SaveChangesAsync();
            }
        }

    }
}
