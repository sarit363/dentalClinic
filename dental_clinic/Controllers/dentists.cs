using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Models;

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
        public ActionResult Post([FromBody] dentistPostModels d)
        {
            var newDentist = new dentist { Name = d.Name, Phone_number = d.Phone_number, Status = d.Status, Email = d.Email, Salary = d.Salary, Identity = d.Identity };
            var den = _dentistService.GetById(newDentist.Id);
            if (den != null)
            {
                return Conflict();
            }
            _dentistService.Add(newDentist);
            return Ok();
        }

        // PUT api/<dentists>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] dentistPostModels d)
        {
            var newDentist = new dentist { Name = d.Name, Phone_number = d.Phone_number, Status = d.Status, Email = d.Email, Salary = d.Salary, Identity = d.Identity };
            var dentist = _dentistService.Update(id, newDentist);
            if (dentist != null)
            {
                return Ok(dentist);
            }
            return NotFound();
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
