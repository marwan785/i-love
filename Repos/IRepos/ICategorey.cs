using HabitTracker.Models.Entites;

namespace HabitTracker.Repos.IRepos
{
    public interface ICategorey
    {
        public Task<IEnumerable<Category>> GetAllCategories();
    }
}
