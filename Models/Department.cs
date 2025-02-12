﻿using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Manager { get; set; }

        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Trainee>? Trainees { get; set; }

    }
}
