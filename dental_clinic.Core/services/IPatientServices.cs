using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IPatientServices
    {
        public Task<List<patient>> GetListAsync();
        public patient GetById(string id);
        public Task AddAsync(patient patientA);
        public void Remove(patient patient);
        public Task<patient> UpdateAsync(string id, patient patient);
    }
}