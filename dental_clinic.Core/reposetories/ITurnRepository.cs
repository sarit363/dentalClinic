using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface ITurnRepository
    {
        public List<turn> GetAll();
        public void Add(turn turn);
        public turn GetById(int id);
        public void Remove(turn turn);
        public void Update(turn updatedTurn);
    }
}
