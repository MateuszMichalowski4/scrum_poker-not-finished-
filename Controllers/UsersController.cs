using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.Context;
using Poker.DTOs;
using Poker.Models;

namespace Poker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ScrumPokerContext _context;

        public UsersController(ScrumPokerContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

      
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO userDto)
        {
            User user = new User { Username = userDto.Username };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

    }

}
