using HabitTracker.Models.Entites;

namespace HabitTracker.Repos.IRepos
{
    public interface IUserRepo
    {
        public Task<IEnumerable<User>> GetAllUsers() ;
        public Task AddUser(User user);
        public Task<User> GetById(int id);
         public Task<User> GetUserWithHabitList(int Id);
        public Task DeleteUser(User user);
    }
}
