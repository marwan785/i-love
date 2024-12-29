using HabitTracker.Models;
using HabitTracker.Models.Entites;
using HabitTracker.Repos.IRepos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace HabitTracker.Repos.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _appDbContext;

        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddUser(User user)
        {
            if(user !=null)
            {
                await _appDbContext.AddAsync(user);
               await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(User user)
        {
            _appDbContext.users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _appDbContext.users.ToListAsync();
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _appDbContext.users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetUserWithHabitList(int Id)
        {
            var use = await _appDbContext.users.Include(h => h.Habits)
                                   .ThenInclude(c => c.Category)
                                   .FirstOrDefaultAsync(u => u.Id == Id);
            return use;
        }



        //public async Task AddUser(User user)
        //{
        //    if (user != null)
        //    {
        //        await _appDbContext.AddAsync(user);
        //        await _appDbContext.SaveChangesAsync();
        //    }
        //}

        //public async Task DeleteUser(User user)
        //{
        //    _appDbContext.Remove(user);
        //    await _appDbContext.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<User>> GetAllUsers()
        //{
        //    return await _appDbContext.users.ToListAsync();
        //}

        //public async Task<User> GetUserWithHabitList(int Id)
        //{
        //    return await _appDbContext.users.Include(h => h.Habits)
        //                .ThenInclude(c => c.Category)
        //                .FirstOrDefaultAsync(u => u.Id == Id);


        //}



        //public async Task<User> GetById(int id)
        //{
        //    var user = await _appDbContext.users.FirstOrDefaultAsync(u => u.Id == id);
        //    //  if (user == null) return NotFound("User Not Found");
        //    return user;
        //}


    }
}
