using HabitTracker.Models.Entites;
using HabitTracker.Models;
using HabitTracker.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Repos.Implementation
{
    public class CategoryRepo : ICategorey
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepo( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var Categories = await _appDbContext.Categories.ToListAsync();
            return Categories;
        }

    
    }
}
