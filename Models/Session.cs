namespace Poker.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScrumMasterId { get; set; }
        public User ScrumMaster { get; set; }
        public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public ICollection<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
    }


}
