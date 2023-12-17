using Microsoft.AspNetCore.Mvc;
using Poker.Context;
using Poker.DTOs;
using Poker.Models;

namespace Poker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ScrumPokerContext _context;

        public TaskItemsController(ScrumPokerContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IEnumerable<TaskItem> GetTaskItems()
        {
            return _context.TaskItems.ToList();
        }

        
        [HttpPost]
        public IActionResult CreateTaskItem([FromBody] TaskItemDTO taskItemDto)
        {
            TaskItem taskItem = new TaskItem { Description = taskItemDto.Description, SessionId = taskItemDto.SessionId };
            _context.TaskItems.Add(taskItem);
            _context.SaveChanges();
            return Ok(taskItem);
        }

    }

}
