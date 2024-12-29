using HabitTracker.Models.Entites;
using HabitTracker.Models.ViewModels;

namespace HabitTracker.Repos.IRepos
{
    public interface IHabitRepo
    {
        public Task<IEnumerable<Habit>> GetAllHabits();
        public Task CreateHabit(HabitViewModel habit);
        public Task<IEnumerable<Habit>> GetHabitByUserId(int id);
        public Task DeleteHabit(Habit Habit);
        public Task UpdateHabit(HabitViewModel habit);
    }
}
