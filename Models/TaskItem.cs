﻿namespace Poker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public ICollection<Estimation> Estimations { get; set; } = new List<Estimation>();
    }
}
