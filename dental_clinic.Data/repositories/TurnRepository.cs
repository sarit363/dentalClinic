using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class TurnRepository: ITurnRepository
    {
        private readonly DataContext _context;
        public TurnRepository(DataContext context)
        {
            _context = context;
        }
        public List<turn> GetAll()
        {
            return _context.Turns;
        }
    }
}
