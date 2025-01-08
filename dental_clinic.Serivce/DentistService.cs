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
    public class DentistService : IDentistServices
    {
        private readonly IDentistRepository _dentistRepository;
        public DentistService(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }
        public dentist GetById(string id)
        {
            return _dentistRepository.GetById(id);
        }
        public IEnumerable<dentist> GetList()
        {
            return _dentistRepository.GetAll();
        }
        public void Add(dentist dentist)
        {
            _dentistRepository.Add(dentist);
        }
        public void Remove(dentist dentist) 
        {
            _dentistRepository.Remove(_dentistRepository.GetById(dentist.Id));
        }
        //public void Put(dentist updatedDentist)
        //{
        //    _dentistRepository.Update(updatedDentist);
        //}
        public dentist Update(int id, dentist dentist)
        {
            //לוגיקה
            return _dentistRepository.Update(id, dentist);
        }

    }
}
