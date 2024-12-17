using Academy.Data;
using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repos
{
    public class CourseRepo : ICourseRepo
    {
        private readonly AppDbContext _context;

        public CourseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
