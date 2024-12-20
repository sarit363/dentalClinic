﻿using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface ITurnServices
    {
        public IEnumerable<turn> GetList();
        public turn GetById(string id);
        public void Add(turn turn);
        public void Remove(turn turn);
        public void Put(turn updatedTurn);
    }
}
