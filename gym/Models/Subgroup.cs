using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gym.Models
{
    [Table("subgroups")]
    public class Subgroup
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("level")]
        public string Level { get; set; } = null!;

        [Column("direction_id")]
        public int DirectionId { get; set; }
    }
}
