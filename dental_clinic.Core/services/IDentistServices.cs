using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IDentistServices
    {
        public Task<List<dentist>> GetListAsync();
        public dentist GetById(string id);
        public Task AddAsync(dentist dentist);
        public void Remove(dentist dentist);
        public Task<dentist> UpdateAsync(string id, dentist dentist);
    }
}
