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
        public async Task<List<patient>> GetListAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task AddAsync(patient patientA)
        {
            await _patientRepository.AddAsync(patientA);
        }
        public void Remove(patient patient)
        {
            _patientRepository.Remove(_patientRepository.GetById(patient.Id));
        }
        public async Task<patient> UpdateAsync(string id, patient patient)
        {
            //לוגיקה
            return await _patientRepository.UpdateAsync(id, patient);
        }
    }

}
