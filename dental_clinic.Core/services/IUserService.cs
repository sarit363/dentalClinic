﻿using dental_clinic.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IUserService
    {
        public Task<User> GetByUserNameAsync(string userName, string Password);
        public Task<User> AddUserAsync(User user);
    }
}
