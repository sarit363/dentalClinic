using System.ComponentModel.DataAnnotations;

namespace dental_clinic.Models
{
    public class turnPostModels
    {
        public string Date { get; set; }
        public int TurnNum { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public int DurantionOfTreatment { get; set; }
        public string DoctorName { get; set; }

    }
}
