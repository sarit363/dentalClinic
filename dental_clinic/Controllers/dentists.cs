using dental_clinic.Core.services;
using dental_clinic.entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistService _dentistService;
        public DentistsController(IDentistService dentistService)
        {
            _dentistService = dentistService;
        }
        //public readonly DataContext _context;
        //public dentists(DataContext context)
        //{
        //    _context = context;
        //}

        //private static List<dentist> Dentists = new List<dentist> {
        //new dentist{Name="john fox",Id=128856789,Phone_number=0527554288,Status="dentist",Email="nbjks@gmail.com",Salary=3000},
        //new dentist{Name="harry gong",Id=128999789,Phone_number=0563554288,Status="doctor",Email="bnjks@gmail.com",Salary=6000},
        //new dentist{Name="dan vec",Id=128888789,Phone_number=0577554288,Status="doctor",Email="nbjnms@gmail.com",Salary=4000}
        //};
        // GET: api/<dentists>
        [HttpGet]

        public ActionResult Get()
        {
            return Ok(_dentistService.GetList());
        }


        // GET api/<dentists>/5
        [HttpGet("{id}")]
        public int Getid(int id)
        {
            return id;
        }

        // POST api/<dentists>
        [HttpPost]
        public dentist Post([FromBody] dentist value)
        {
            _context.Dentists.Add(value);
            return value;
        }

        // PUT api/<dentists>/5
        [HttpPut("{id}")]
        public dentist Put(int id, [FromBody] dentist value)
        {
            var index = _context.Dentists.FindIndex(e => e.Id == id);
            _context.Dentists[index].Name = value.Name;
            _context.Dentists[index].Phone_number = value.Phone_number;
            _context.Dentists[index].Status = value.Status;
            _context.Dentists[index].Email = value.Email;
            _context.Dentists[index].Salary = value.Salary;
            return _context.Dentists[index];
        }

        // DELETE api/<dentists>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
