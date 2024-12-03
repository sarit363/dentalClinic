using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistServices _dentistService;
        public DentistsController(IDentistServices dentistService)
        {
            _dentistService = dentistService;
        }
        [HttpGet]

        public ActionResult Get()
        {
            return Ok(_dentistService.GetList());
        }


        // GET api/<dentists>/5
        [HttpGet("{id}")]
        public ActionResult Getid(string id)
        {
            var den = _dentistService.GetById(id);
            if (den != null)
            {
                return Ok(den);
            }
            return NotFound();
        }

        // POST api/<dentists>
        [HttpPost]
        public ActionResult Post([FromBody] dentist d)
        {
            var den = _dentistService.GetById(d.Id);
            if (den != null)
            {
                return Conflict();
            }
            _dentistService.Add(d);
            return Ok();
        }

        // PUT api/<dentists>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] dentist value)
        {
            var existingDentist = _dentistService.GetById(id);

            if (existingDentist == null)
            {
                return NotFound(); // אם הרופא לא נמצא, נחזיר שגיאה 404
            }

            try
            {
                // עדכון כל השדות של האובייקט הקיים לפי הערכים החדשים
                existingDentist.Name = value.Name;
                existingDentist.Status = value.Status;
                existingDentist.Email = value.Email;
                existingDentist.Salary = value.Salary;
                existingDentist.Phone_number = value.Phone_number;
                existingDentist.Id = value.Id;

                // קריאה לשירות לעדכון הרופא
                _dentistService.Put(existingDentist);

                return NoContent(); // החזרה של 204 במידה והעדכון עבר בהצלחה
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<dentists>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var dentist = _dentistService.GetById(id);
            if (dentist == null)
            {

                return NotFound();
            }
            try
            {
                _dentistService.Remove(dentist);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
