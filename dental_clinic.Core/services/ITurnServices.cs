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
        public turn GetById(string id);
        public Task<List<turn>> GetListAsync();
        public Task AddAsync(turn turn);
        public void Remove(turn turn);
        public turn Update(int id, turn turn);
    }
}
