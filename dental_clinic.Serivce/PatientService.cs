using dental_clinic.Core.entities;
using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using dental_clinic.Data.repositories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class PatientService: IPatientServices
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public List<patient> GetList()
        {
            return _patientRepository.GetAll();
        }
    }
}
