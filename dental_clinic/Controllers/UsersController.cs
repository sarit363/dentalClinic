using AutoMapper;
using dental_clinic.Core.entities;
using dental_clinic.Core.services;
using dental_clinic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dental_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
       
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
      
        // מחזיר את כל המשתמשים
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userService.GetListAsync();
            var userDto = _mapper.Map<List<User>>(users);
            return Ok(userDto);
        }
        
        // מחזיר משתמש לפי מזהה
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // מוסיף משתמש חדש עם Mapper
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }

            var userEntity = _mapper.Map<User>(userModel);
            var createdUser = await _userService.AddAsync(userEntity);

            var userDto = _mapper.Map<User>(createdUser);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        // מעדכן משתמש קיים
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var updatedUser = _userService.Update(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        // מוחק משתמש לפי מזהה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _userService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
