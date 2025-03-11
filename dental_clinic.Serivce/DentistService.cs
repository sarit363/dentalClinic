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
        public async Task<dentist> GetById(string id)
        {
            return await _dentistRepository.GetByIdAsync(id);
        }
        public async Task<List<dentist>> GetListAsync()
        {
            return await _dentistRepository.GetAllAsync();
        }
        public async Task AddAsync(dentist dentist)
        {
           await _dentistRepository.AddAsync(dentist);
        }
        public async Task Remove(dentist dentist) 
        {
            //var den = await _dentistRepository.GetByIdAsync(dentist.Id);
            _dentistRepository.Remove(await _dentistRepository.GetByIdAsync(dentist.Id));
        }
        //public void Put(dentist updatedDentist)
        //{
        //    _dentistRepository.Update(updatedDentist);
        //}
        public async Task<dentist> UpdateAsync(string id, dentist dentist)
        {
            //לוגיקה
            return await _dentistRepository.UpdateAsync(id, dentist);
        }

        //public Task<dentist> GetById(id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
