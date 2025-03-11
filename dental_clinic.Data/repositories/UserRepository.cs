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
        private readonly DataContext _context;
        //Users
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public User GetById(string id)
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public User Update(string id, User user)
        {
            var existingUser = _context.User.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
               
                existingUser.Password = user.Password;
                _context.SaveChanges();
                return existingUser;
            }
            return null;
        }

        public async Task Delete(string id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
