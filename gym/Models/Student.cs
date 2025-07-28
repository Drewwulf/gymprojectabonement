using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace gym.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = null!;

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        [Column("photo_url")]
        public string? PhotoUrl { get; set; }

        [Column("subscription_id")]
        public int? SubscriptionId { get; set; }

        [Column("subscription_start")]
        public DateTime? SubscriptionStart { get; set; }

        [Column("subscription_end")]
        public DateTime? SubscriptionEnd { get; set; }
    }
}
