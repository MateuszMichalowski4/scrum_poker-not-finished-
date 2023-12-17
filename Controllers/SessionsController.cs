using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poker.Context;
using Poker.DTOs;
using Poker.Models;

namespace Poker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ScrumPokerContext _context;

        public SessionsController(ScrumPokerContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Session> GetSessions()
        {
            return _context.Sessions.ToList();
        }

       
        [HttpPost]
        public IActionResult CreateSession([FromBody] SessionDTO sessionDto)
        {
            Session session = new Session { Name = sessionDto.Name, ScrumMasterId = sessionDto.ScrumMasterId };
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return Ok(session);
        }

       
        [HttpPost("api/SessionUsers/AddUserToSession")]
        public IActionResult AddUserToSession([FromBody] SessionUserDTO sessionUserDto)
        {
            
            var userExists = _context.Users.Any(u => u.Id == sessionUserDto.UserId);
            var sessionExists = _context.Sessions.Any(s => s.Id == sessionUserDto.SessionId);

            if (!userExists || !sessionExists)
            {
                return NotFound("User or Session not found");
            }

            
            var relationExists = _context.SessionUsers.Any(su => su.UserId == sessionUserDto.UserId && su.SessionId == sessionUserDto.SessionId);

            if (relationExists)
            {
                return BadRequest("User already added to the session");
            }

            SessionUser sessionUser = new SessionUser { UserId = sessionUserDto.UserId, SessionId = sessionUserDto.SessionId };
            _context.SessionUsers.Add(sessionUser);
            _context.SaveChanges();

            return Ok(sessionUser);
        }


    }

}