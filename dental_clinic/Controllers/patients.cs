using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Serivce;
using dental_clinic.Core.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientServices _patientService;
        public PatientsController(IPatientServices patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]

        public ActionResult Get()
        {
            return Ok(_patientService.GetList());
        }

        // GET api/<patients>/5
        [HttpGet("{id}")]
        public ActionResult Getid(int id)
        {
            var den = _patientService.GetById(id);
            if (den != null)
            {
                return Ok(den);
            }
            return NotFound();
        }
        // POST api/<patients>
        [HttpPost]
        public ActionResult Post([FromBody] patient d)
        {
            var den = _patientService.GetById(d.Id);
            if (den != null)
            {
                return Conflict();
            }
            _patientService.Add(d);
            return Ok();

        }

        // PUT api/<patients>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] patient value)
        {
            var existingPatient = _patientService.GetById(id);

            if (existingPatient == null)
            {
                return NotFound(); // אם הרופא לא נמצא, נחזיר שגיאה 404
            }

            try
            {
                // עדכון כל השדות של האובייקט הקיים לפי הערכים החדשים
                existingPatient.Name = value.Name;
                existingPatient.Status = value.Status;
                existingPatient.Email = value.Email;
                existingPatient.Address = value.Address;
                existingPatient.Phone_number = value.Phone_number;
                existingPatient.Id = value.Id;

                // קריאה לשירות לעדכון הרופא
                _patientService.Put(existingPatient);

                return NoContent(); // החזרה של 204 במידה והעדכון עבר בהצלחה
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<patients>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {

                return NotFound();
            }
            try
            {
                _patientService.Remove(patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
