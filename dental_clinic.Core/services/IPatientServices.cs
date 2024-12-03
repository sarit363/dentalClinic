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
        public IEnumerable<patient> GetList();
        public patient GetById(string id);
        public void Add(patient patientA);
        public void Remove(patient patient);
        public void Put(dentist updatedPatient);
        public void Put(patient existingPatient);
    }
}