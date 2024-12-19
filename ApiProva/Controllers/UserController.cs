using ApiProva.Database;
using ApiProva.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace ApiProva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly FakeDatabase fakeDB = new();

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllUsers()
        {
            return Ok(fakeDB.Users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int id)
        {
            var user = fakeDB.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound(new { Message = $"User with ID {id} not found." });

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddUser([FromBody] AddUserRequest user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newUser = new User
            {
                Id = fakeDB.Users.Any() ? fakeDB.Users.Max(u => u.Id) + 1 : 1,
                Name = user.Name!,
                Surname = user.Surname!,
                Email = user.Email!
            };

            fakeDB.Users.Add(newUser);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserRequest user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userFound = fakeDB.Users.FirstOrDefault(x => x.Id == id);

            if (userFound == null)
                return NotFound(new { Message = $"User with ID {id} not found." });

            userFound.Name = user.Name!;
            userFound.Surname = user.Surname!;
            userFound.Email = user.Email!;

            return Ok(userFound);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int id)
        {
            var user = fakeDB.Users.FirstOrDefault(x => x.Id == id);
            
            if (user == null)
                return NotFound(new { Message = $"User with ID {id} not found." });

            fakeDB.Users.Remove(user);

            return Ok(new { Message = $"User with ID {id} deleted successfully." });
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAllUsers()
        {
            fakeDB.Users.Clear();
            return Ok(new { Message = "All users have been deleted." });
        }
    }

}
