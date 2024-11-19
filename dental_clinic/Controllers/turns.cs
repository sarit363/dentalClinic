using dental_clinic.entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class turns : ControllerBase
    {
        public readonly DataContext _context;
        public turns(DataContext context)
        {
            _context = context;
        }
        //private static List<turn> Turn = new List<turn> {
        //    new turn{ Date="31.1.25",TurnNum=56,Time="5:30",Type="braces",DurantionOfTreatment=45,DoctorName="john fox"},
        //    new turn{ Date="12.2.25",TurnNum=98,Time="15:40",Type="root canal",DurantionOfTreatment=60,DoctorName="john fox"},
        //    new turn{ Date="08.8.25",TurnNum=86,Time="18:00",Type="crown",DurantionOfTreatment=25,DoctorName="harry gong"},
        //    new turn{ Date="26.9.25",TurnNum=23,Time="8:30",Type="teeth cleaning",DurantionOfTreatment=15,DoctorName="dan vec"},
        //    new turn{ Date="13.1.25",TurnNum=54,Time="12:20",Type="dentures",DurantionOfTreatment=30,DoctorName="harry gong"}
        //};  
        // GET: api/<turns>
        [HttpGet]
        public IEnumerable<turn> Get()
        {
            return _context.Turn;
        }

        // GET api/<turns>/5
        [HttpGet("{id}")]
        public int Getid(int turnnum)
        {
            return turnnum;
        }

        // POST api/<turns>
        [HttpPost]
        public turn Post([FromBody] turn value)
        {
            _context.Turn.Add(value);
            return value;
        }

        // PUT api/<turns>/5
        [HttpPut("{id}")]
        public turn Put(int turnnum, [FromBody] turn value)
        {
            var index = _context.Turn.FindIndex(e => e.TurnNum == turnnum);
            _context.Turn[index].Date = value.Date;
            _context.Turn[index].Time = value.Time;
            _context.Turn[index].Type = value.Type;
            _context.Turn[index].DurantionOfTreatment = value.DurantionOfTreatment;
            _context.Turn[index].DoctorName = value.DoctorName;
            return _context.Turn[index];
        }

        // DELETE api/<turns>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
