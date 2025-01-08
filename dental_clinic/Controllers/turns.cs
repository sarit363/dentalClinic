using Microsoft.AspNetCore.Mvc;
using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        private readonly ITurnServices _turnService;
        public TurnsController(ITurnServices turnService)
        {
            _turnService = turnService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_turnService.GetList());
        }

        // GET api/<turns>/5
        [HttpGet("{id}")]
        public ActionResult Getid(string id)
        {
            var den = _turnService.GetById(id);
            if (den != null)
            {
                return Ok(den);
            }
            return NotFound();
        }

        // POST api/<turns>
        [HttpPost]
        public ActionResult Post([FromBody] turnPostModels d)
        {
            var newTurn = new turn { Date = d.Date, TurnNum = d.TurnNum, Time = d.Time, Type = d.Type, DurantionOfTreatment = d.DurantionOfTreatment, DoctorName = d.DoctorName };
            var den = _turnService.GetById(newTurn.Id);
            if (den != null)
            {
                return Conflict();
            }
            _turnService.Add(newTurn);
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
