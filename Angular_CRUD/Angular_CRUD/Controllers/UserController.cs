using Angular_CRUD.Data;
using Angular_CRUD.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound(new { message = $"User with Id {id} not found" });

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user.age < 18)
                return BadRequest(new { Message = "Age 18 plus allowed" });
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new {Message = "Data Successfully added"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return NotFound(new { message = $"User with Id {id} not found" });
            if (user.age < 18)
                return BadRequest(new { Message = "Age 18 plus allowed" });
            existingUser.Name = user.Name;
            existingUser.Department = user.Department;
            existingUser.age = user.age;
            existingUser.IsActive = user.IsActive;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Successfully updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = $"User with Id {id} not found" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Successfully Deleted" });
        }

    }
}
