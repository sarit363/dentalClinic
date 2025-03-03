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
    public class TurnService : ITurnServices
    {
        private readonly ITurnRepository _turnRepository;
        public TurnService(ITurnRepository turnRepository)
        {
            _turnRepository = turnRepository;
        }
        public async Task<turn> GetById(string id)
        {
            return await _turnRepository.GetByIdAsync(id);
        }
        public async Task<List<turn>> GetListAsync()
        {
            return await _turnRepository.GetAllAsync();
        }

        public async Task AddAsync(turn turn)
        {
            await _turnRepository.AddAsync(turn);
        }
        public async Task Remove(turn turn)
        {
            _turnRepository.Remove(await _turnRepository.GetByIdAsync(turn.Id));
        }
        public async Task<turn> UpdateAsync(string id, turn turn)
        {
            //לוגיקה
            return await _turnRepository.UpdateAsync(id, turn);
        }
    }

}
