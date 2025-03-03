using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface ITurnServices
    {
        public Task<turn> GetById(string id);
        public Task<List<turn>> GetListAsync();
        public Task AddAsync(turn turn);
        public Task Remove(turn turn);
        public Task<turn> UpdateAsync(string id, turn turn);
    }
}
