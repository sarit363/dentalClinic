using dental_clinic.entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class patients : ControllerBase
    {
        public readonly DataContext _context;
        public patients(DataContext context)
        {
            _context = context;
        }
        //private static List<patient> Patients = new List<patient> {
        //    new patient{Name="sarit gruzman",Id=123456789,Phone_number=0527644288,Status="adult",Email="nbjks@gmail.com",Address="desler 10,bnei brak"},
        //    new patient{Name="noa amir",Id=987654321,Phone_number=0548423265,Status="adult",Email="kjjbvsdk@gmail.com",Address="ben kuk,bnei brak"}
        //    new patient{Name="ron popes",Id=215182932,Phone_number=0522244765,Status="child",Email="NULL",Address="YUTA 20,ramat gan"},
        //    new patient{Name="peter dan",Id=123454321,Phone_number=0583270079,Status="adult",Email="hfdb6464@gmail.com",Address="yosei 19,bnei brak"}

        //    };
        // GET: api/<patients>
        [HttpGet]

        public IEnumerable<patient> Get()
        {
            return _context.Patients;
        }

        // GET api/<patients>/5
        [HttpGet("{id}")]
        public int GetId(int id)
        {
            return id;
        }

        // POST api/<patients>
        [HttpPost]
        public patient Post([FromBody] patient value)
        {
            _context.Patients.Add(value);
            return value;
        }

        // PUT api/<patients>/5
        [HttpPut("{id}")]
        public patient Put(int id, [FromBody] patient value)
        {
            var index= _context.Patients.FindIndex(e=> e.Id==id);
            _context.Patients[index].Name = value.Name;
            _context.Patients[index].Phone_number = value.Phone_number;
            _context.Patients[index].Status = value.Status;
            _context.Patients[index].Email = value.Email;
            _context.Patients[index].Address = value.Address;
            return _context.Patients[index];
        }

        // DELETE api/<patients>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
