using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class PatientService : IPatientServices
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public patient GetById(string id)
        {
            return _patientRepository.GetById(id);
        }
        public IEnumerable<patient> GetList()
        {
            return _patientRepository.GetAll();
        }

        public void Add(patient patientA)
        {
            _patientRepository.Add(patientA);
        }
        public void Remove(patient patient)
        {
            _patientRepository.Remove(_patientRepository.GetById(patient.Id));
        }
        public void Put(patient updatedPatient)
        {
            _patientRepository.Update(updatedPatient);
        }

        public void Put(dentist updatedPatient)
        {
            throw new NotImplementedException();
        }
    }

}
