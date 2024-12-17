using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }


        [DisplayName("Image")]
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }


        [DisplayName("Department")]
        public int? DepId { get; set; }
        [ForeignKey("DepId")]

        public Department? Department { get; set; }

        [DisplayName("Course Name")]
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

        public ICollection<CourseResult>? Courses { get; set; }

    }
}
