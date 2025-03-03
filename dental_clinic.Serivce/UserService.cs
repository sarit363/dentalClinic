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
        public async Task<User> GetByUserNameAsync(string userName, string Password)
        {
            return await _userRepository.GetByUserNmaeAsync(userName, Password);
        }
        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }
    }
}
