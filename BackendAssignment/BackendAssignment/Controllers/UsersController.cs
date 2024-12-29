using BackendAssignment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendAssignment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;

namespace BackendAssignment.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }


        [HttpPost("login", Name = "LoginUser")]
        public async Task<ActionResult<User>> LoginUser(User currentUser)
        {
            // Search for the user by email
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == currentUser.Email);

            // Check if the user is found
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Validate password (in a real-world app, this should be hashed and compared)
            if (user.PasswordHash != currentUser.PasswordHash)
            {
                return Unauthorized("Invalid email or password.");
            }

            // If everything is correct, return the user data
            return Ok(user);
        }
    }
}
