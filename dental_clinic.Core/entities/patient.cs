using dental_clinic.Core.entities;
using System.ComponentModel.DataAnnotations;

namespace dental_clinic.entities
{
    public class patient
    {
        public string Name { get; set; }
        [Key]
        public string Id { get; set; }
        public int Phone_number { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string Identity { get; set; }
        public string TurnId { get; set; }
        public turn turn { get; set; }
        public string UserId { get; set; }
        public User user { get; set; }
    }
}
