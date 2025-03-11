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
        Task<List<User>> GetAllAsync();  // מחזיר את כל המשתמשים
        User GetById(string id);  // מחזיר משתמש לפי מזהה
        Task AddAsync(User user);  // מוסיף משתמש חדש
        User Update(string id, User user);  // מעדכן משתמש קיים
        Task Delete(string id);
    }
}
