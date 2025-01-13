using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Models;
using dental_clinic.Core.DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistServices _dentistService;
        private readonly IMapper _mapper;
        public DentistsController(IDentistServices dentistService, IMapper map)
        {
            _dentistService = dentistService;
            _mapper = map;
        }
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var dentistList =await _dentistService.GetListAsync();
            var dentists = _mapper.Map<IEnumerable<dentistDto>>(dentistList);
            return Ok(dentists);
        }


        // GET api/<dentists>/5
        [HttpGet("{id}")]
        public ActionResult Getid(string id)
        {
            var dent = _dentistService.GetById(id);
            var dentist = _mapper.Map<dentistDto>(dent);
            if (dent != null)
            {
                return Ok(dentist);
            }
            return NotFound();
        }

        // POST api/<dentists>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] dentistPostModels d)
        {
            var newDentist = new dentist { Name = d.Name, Phone_number = d.Phone_number, Status = d.Status, Email = d.Email, Salary = d.Salary, Identity = d.Identity };
            var den = _dentistService.GetById(newDentist.Id);
            if (den != null)
            {
                return Conflict();
            }
            await _dentistService.AddAsync(newDentist);
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
