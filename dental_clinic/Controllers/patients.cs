using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Serivce;
using dental_clinic.Core.services;
using dental_clinic.Models;
using dental_clinic.Core.DTOs;
using AutoMapper;
using dental_clinic.Core.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientServices _patientService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public PatientsController(IPatientServices patientService, IMapper map, IUserService userService)
        {
            _patientService = patientService;
            _mapper = map;
            _userService = userService;
        }
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var patientsList =await _patientService.GetListAsync();
            var patients = _mapper.Map<IEnumerable<patientDto>>(patientsList);
            return Ok(patients);
        }

        // GET api/<patients>/5
        [HttpGet("{id}")]
        public ActionResult Getid(string id)
        {
            var ptn = _patientService.GetById(id);
            var patient = _mapper.Map<patientDto>(ptn);
            if (ptn != null)
            {
                return Ok(patient);
            }
            return NotFound();
        }
        // POST api/<patients>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] patientPostModels d)
        {
            var user = new User { UserName = d.UserName, Password = d.Password, Role = eRole.patient };
            var User = await _userService.AddUserAsync(user);
            var patient = _mapper.Map<patient>(d);
            patient.user = User;
            patient.UserId = User.Id;
            //var newPatient = new patient { Name = d.Name, Address =  d.Address, Email = d.Email, Phone_number = d.Phone_number, Status = d.Status,Identity = d.Identity  };
            var den =await _patientService.GetById(patient.Id);
            if (den != null)
            {
                return Conflict();
            }
            await _patientService.AddAsync(patient);
            return Ok();

        }

        // PUT api/<patients>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] patientPostModels d)
        {
            var patientt = _patientService.UpdateAsync(id, _mapper.Map<patient>(d));
            //var newPatient = new patient { Name = d.Name, Email = d.Email, Phone_number = d.Phone_number, Status = d.Status, Identity = d.Identity };
            var patient = await _patientService.UpdateAsync(id, await patientt);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound();
        }

        // DELETE api/<patients>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var patient =await _patientService.GetById(id);
            if (patient == null)
            {

                return NotFound();
            }
            try
            {
              await  _patientService.Remove(patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
