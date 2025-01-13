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
        public turn GetById(string id)
        {
            return _turnRepository.GetById(id);
        }
        public async Task<List<turn>> GetListAsync()
        {
            return await _turnRepository.GetAllAsync();
        }

        public async Task AddAsync(turn turn)
        {
            await _turnRepository.AddAsync(turn);
        }
        public void Remove(turn turn)
        {
            _turnRepository.Remove(_turnRepository.GetById(turn.Id));
        }
        public turn Update(int id, turn turn)
        {
            //לוגיקה
            return _turnRepository.Update(id, turn);
        }
    }

}
