using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Serivce;
using dental_clinic.Core.services;
using dental_clinic.Models;

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
        public ActionResult Getid(string id)
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
        public ActionResult Post([FromBody] patientPostModels d)
        {
            var newPatient = new patient { Name = d.Name, Address =  d.Address, Email = d.Email, Phone_number = d.Phone_number, Status = d.Status,Identity = d.Identity  };
            var den = _patientService.GetById(newPatient.Id);
            if (den != null)
            {
                return Conflict();
            }
            _patientService.Add(newPatient);
            return Ok();

        }

        // PUT api/<patients>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] patientPostModels d)
        {
            var newPatient = new patient { Name = d.Name, Email = d.Email, Phone_number = d.Phone_number, Status = d.Status, Identity = d.Identity };
            var patient = _patientService.Update(id, newPatient);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound();
        }

        // DELETE api/<patients>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
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
