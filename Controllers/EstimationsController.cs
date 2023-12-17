using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.Context;
using Poker.DTOs;
using Poker.Models;

namespace Poker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstimationsController : ControllerBase
    {
        private readonly ScrumPokerContext _context;

        public EstimationsController(ScrumPokerContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Estimation> GetEstimations()
        {
            return _context.Estimations.ToList();
        }

        
        [HttpPost]
        public IActionResult CreateEstimation([FromBody] EstimationDTO estimationDto)
        {
            Estimation estimation = new Estimation { Value = estimationDto.Value, UserId = estimationDto.UserId, TaskItemId = estimationDto.TaskItemId };
            _context.Estimations.Add(estimation);
            _context.SaveChanges();
            return Ok(estimation);
        }

    }

}
