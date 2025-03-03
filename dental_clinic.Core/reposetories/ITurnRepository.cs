using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface ITurnRepository
    {
        public Task<List<turn>> GetAllAsync();
        public Task AddAsync(turn turn);
        public Task<turn> GetByIdAsync(string id);
        public void Remove(turn turn);
        public Task<turn> UpdateAsync(string id, turn NewTurn);
    }
}
