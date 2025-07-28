using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gym.Models
{
    [Table("subscriptions")]
    public class Subscription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("duration_days")]
        public int DurationDays { get; set; }
    }
}
