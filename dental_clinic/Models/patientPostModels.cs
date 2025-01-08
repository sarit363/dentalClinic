using System.ComponentModel.DataAnnotations;

namespace dental_clinic.Models
{
    public class patientPostModels
    {
        public string Name { get; set; }
        public int Phone_number { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string Identity { get; set; }
    }
}
