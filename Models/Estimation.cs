namespace Poker.Models
{
    public class Estimation
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
