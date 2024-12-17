using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public int TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public Trainee? Trainee { get; set; }

    }
}
