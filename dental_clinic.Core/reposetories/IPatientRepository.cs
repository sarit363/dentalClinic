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
        public IEnumerable<patient> GetAll();
        public void Add(patient patient);
        public patient GetById(string id);
        public void Remove(patient patient);
        public void Update(patient updatedPatient);
    }
}
