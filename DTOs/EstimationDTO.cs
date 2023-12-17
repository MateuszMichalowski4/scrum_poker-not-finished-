using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Poker.DTOs
{
    public class EstimationDTO
    {
        public int Value { get; set; }
        public int UserId { get; set; }
        public int TaskItemId { get; set; }
    }

}
