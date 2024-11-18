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
    public class TurnService: ITurnServices
    {
        private readonly ITurnRepository _turnRepository;
        public TurnService(ITurnRepository turnRepository)
        {
            _turnRepository = turnRepository;
        }
        public List<turn> GetList()
        {
            return _turnRepository.GetAll();
        }
    }
}
