using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.DTOs
{
    public class patientDto
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Phone_number { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string Identity { get; set; }
    }
}
