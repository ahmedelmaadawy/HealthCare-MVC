﻿namespace HealthCare.DataAccess.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}