using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface IPatientRepository
    {
        public Task<List<patient>> GetAllAsync();
        public Task AddAsync(patient patient);
        public patient GetById(string id);
        public void Remove(patient patient);
        public patient Update(int id, patient NewPatient);
    }
}
