using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Models;
using dental_clinic.Core.DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ITurnServices _turnService;
        private readonly IMapper _mapper;
        public TurnsController(ITurnServices turnService, IMapper map)
        {
            _turnService = turnService;
            _mapper = map;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var turnsList =await _turnService.GetListAsync();
            var turns = _mapper.Map<IEnumerable<turnDto>>(turnsList);
            return Ok(turns);
        }

        // GET api/<turns>/5
        [HttpGet("{id}")]
        public ActionResult Getid(string id)
        {
            var trn = _turnService.GetById(id);
            var turn = _mapper.Map<turnDto>(trn);
            if (trn != null)
            {
                return Ok(turn);
            }
            return NotFound();
        }

        // POST api/<turns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] turnPostModels d)
        {
            var newTurn = new turn { Date = d.Date, TurnNum = d.TurnNum, Time = d.Time, Type = d.Type, DurantionOfTreatment = d.DurantionOfTreatment, DoctorName = d.DoctorName };
            var den = _turnService.GetById(newTurn.Id);
            if (den != null)
            {
                return Conflict();
            }
            await _turnService.AddAsync(newTurn);
            return Ok();

        }

        // PUT api/<turns>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] turnPostModels d)
        {
            var newTurn = new turn { Date = d.Date, TurnNum = d.TurnNum, Time = d.Time, Type = d.Type, DurantionOfTreatment = d.DurantionOfTreatment, DoctorName = d.DoctorName };
            var turn = _turnService.Update(id, newTurn);
            if (turn != null)
            {
                return Ok(turn);
            }
            return NotFound();
        }


        // DELETE api/<turns>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var turn = _turnService.GetById(id);
            if (turn == null)
            {
                return NotFound();
            }
            try
            {
                _turnService.Remove(turn);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
