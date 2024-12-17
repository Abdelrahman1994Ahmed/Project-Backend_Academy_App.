using Academy.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Academy.ViewModels
{
    public class TraineeViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [DisplayName("Image")]
        public string? ImgURL { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }

        [DisplayName("Department")]
        public int DepId { get; set; }

        [DisplayName("Course")]
        public int CourseId { get; set; }
        //public List<Department> Departments { get; set; }
        //public List<Course> Courses { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
