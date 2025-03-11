using dental_clinic.Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IUserService
    {
        Task<List<User>> GetListAsync();  // מחזיר את כל המשתמשים
        User GetById(string id);  // מחזיר משתמש לפי מזהה
        Task<User> AddAsync(User user);  // מוסיף משתמש חדש ומחזיר אותו
        User Update(string id, User user);  // מעדכן משתמש קיים
        Task<bool> Delete(string id);  // מוחק משתמש, מחזיר true אם הצליח, false אם לא    }
        Task<User> AddUserAsync(User user); 
        Task<object> GetByUserNameAsync(string userName, string password);
    }
}
