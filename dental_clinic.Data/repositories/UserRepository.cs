using dental_clinic.Core.entities;
using dental_clinic.Core.reposetories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        public async Task<User> GetByUserNmaeAsync(string userName, string Paaword)
        {
            return await _dataContext.User.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == Paaword);
        }
        public async Task<User> AddUserAsync(User user)
        {
            _dataContext.User.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
    }
}
