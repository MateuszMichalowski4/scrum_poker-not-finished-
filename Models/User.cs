namespace Poker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Estimation> Estimations { get; set; } = new List<Estimation>();
        public ICollection<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
    }

}
