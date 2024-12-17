using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Academy.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [DisplayName("Image")]
        public string? ImgURL { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        [DisplayName("Department")]
        public int? DepId { get; set; }
        [ForeignKey("DepId")]
        public Department? Department { get; set; }

        [DisplayName("Course Name")]
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }

    }
}
