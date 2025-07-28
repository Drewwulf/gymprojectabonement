using System.ComponentModel.DataAnnotations.Schema;

namespace gym.Models
{
    [Table("student_directions")]
    public class StudentDirection
    {
        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("direction_id")]
        public int DirectionId { get; set; }

        [Column("enrolled_date")]
        public DateTime EnrolledDate { get; set; }
    }
}
