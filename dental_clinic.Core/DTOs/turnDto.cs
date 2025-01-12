using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.DTOs
{
    public class turnDto
    {
        public string Date { get; set; }
        public int TurnNum { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public int DurantionOfTreatment { get; set; }
        public string DoctorName { get; set; }
        public string Id { get; set; }
    }
}
