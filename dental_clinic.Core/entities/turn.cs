using System.ComponentModel.DataAnnotations;

namespace dental_clinic.entities
{
    public class turn
    {
        public string Date { get; set; }
        public int TurnNum { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public int DurantionOfTreatment { get; set; }
        public string DoctorName { get; set; }
        [Key]
        public string Id { get; set; }
        public patient patient { get; set; }
        public dentist dentist { get; set; }


    }
}