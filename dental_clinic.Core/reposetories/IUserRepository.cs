using dental_clinic.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface IUserRepository
    {
        public Task<User> GetByUserNmaeAsync(string userName, string Paaword);
        public Task<User> AddUserAsync(User user);
    }
}
