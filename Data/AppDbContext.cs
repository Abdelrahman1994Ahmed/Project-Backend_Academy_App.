using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CourseResult> CoursesResult { get; set; }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}
