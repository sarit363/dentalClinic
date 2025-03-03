using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface IDentistRepository
    {
        public Task<List<dentist>> GetAllAsync();
        public Task AddAsync(dentist entist);
        public IEnumerable<turn> GetList();
        public Task<dentist> GetByIdAsync(string id);
        public void Remove(dentist dentist);
        public Task<dentist> UpdateAsync(string id, dentist NewDentist);


    }
}
