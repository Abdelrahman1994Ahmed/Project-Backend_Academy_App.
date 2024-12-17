using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        public int? DepId { get; set; }
        [ForeignKey("DepId")]
        public Department? Department { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<CourseResult>? CourseResults { get; set; }

    }
}
