using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Models;
using dental_clinic.Core.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using dental_clinic.Core.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//id
    public class DentistsController : ControllerBase
    {
        private readonly IDentistServices _dentistService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public DentistsController(IDentistServices dentistService, IMapper map, IUserService userService)
        {
            _dentistService = dentistService;
            _mapper = map;
            _userService = userService;
        }
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var dentistList = await _dentistService.GetListAsync();
            var dentists = _mapper.Map<IEnumerable<dentistDto>>(dentistList);
            return Ok(dentists);
        }

        // GET api/<dentists>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Getid(string id)
        {
            var dent = await _dentistService.GetById(id); // הוסף await
            if (dent != null)
            {
                var dentist = _mapper.Map<dentistDto>(dent);
                return Ok(dentist);
            }
            return NotFound(); // אם לא נמצא, החזר NotFound
        }

        // POST api/<dentists>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] dentistPostModels d)
        {
            var user = new User { UserName = d.UserName, Password = d.Password, Role = eRole.dentist };
            var User = await _userService.AddUserAsync(user);
            var dentist = _mapper.Map<dentist>(d);
            dentist.user = User;
            dentist.UserId = User.Id;

            //var newDentist = new dentist { Name = d.Name, Phone_number = d.Phone_number, Status = d.Status, Email = d.Email, Salary = d.Salary, Identity = d.Identity };
            var den = await _dentistService.GetById(dentist.Id);
            if (den != null)
            {
                return Conflict();
            }
            await _dentistService.AddAsync(dentist);
            return Ok();
        }

        // PUT api/<dentists>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] dentistPostModels d)
        {
            var dentist = await _dentistService.UpdateAsync(id, _mapper.Map<dentist>(d)); // צריך לחכות עד לסיום הפעולה
            if (dentist != null)
            {
                return Ok(dentist);
            }
            return NotFound();
        }

        // DELETE api/<dentists>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var dentist = await _dentistService.GetById(id);
            if (dentist == null)
            {

                return NotFound();
            }
            try
            {
                await _dentistService.Remove(dentist);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"stringernal server error: {ex.Message}");
            }
        }
    }
}
