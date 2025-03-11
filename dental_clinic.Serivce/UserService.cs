using dental_clinic.Core.entities;
using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetListAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users ?? new List<User>(); // אם החזר null, מחזיר רשימה ריקה
        }


        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;  // מחזיר את המשתמש שנוסף
        }

        public User Update(string id, User user)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
               // existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                return _userRepository.Update(id, existingUser);
            }
            return null;
        }

        public async Task<bool> Delete(string id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                await _userRepository.Delete(id);
                return true;
            }
            return false;
        }
        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            await _userRepository.AddAsync(user);
            //await _userRepository.SaveChangesAsync();

            return user;
        }
        public async Task<object> GetByUserNameAsync(string userName, string password)
        {
            // כאן תוכל להחזיר כל אובייקט שתרצה, במקום Users
            var result = new { UserName = userName, Role = "Admin" };

            // החזר את התוצאה ישירות, אין צורך ב-Task.FromResult כשזו שיטה אסינכרונית
            return result;
        }


    }
}
