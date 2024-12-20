﻿using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class TurnRepository : ITurnRepository
    {
        private readonly DataContext context=new DataContext();
        public IEnumerable<turn> GetAll()
        {
            return context.Turn.Include(p => p.patient);
        }
        public void Add(turn turn)
        {
            context.Turn.Add(turn);
            context.SaveChanges();
        }
        public turn GetById(string id)
        {
            return context.Turn.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(turn turn)
        {
            context.Turn.Remove(turn);
        }
        public void Update(turn updatedTurn)
        {
            var existingTurn = context.Turn.FirstOrDefault(d => d.Id == updatedTurn.Id);

            if (existingTurn != null)
            {
                // עדכון כל השדות של האובייקט הקיים לפי האובייקט החדש
        
                existingTurn.Date = updatedTurn.Date;
                existingTurn.TurnNum = updatedTurn.TurnNum;
                existingTurn.Time = updatedTurn.Time;
                existingTurn.Type = updatedTurn.Type;
                existingTurn.DurantionOfTreatment = updatedTurn.DurantionOfTreatment;
                existingTurn.DoctorName = updatedTurn.DoctorName;
                existingTurn.Id = updatedTurn.Id;



                // שמירת העדכון בבסיס הנתונים
                context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Dentist with ID {updatedTurn.Id} not found.");
            }
        }
    }
}
