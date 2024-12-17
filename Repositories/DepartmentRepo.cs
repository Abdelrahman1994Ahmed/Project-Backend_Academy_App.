using Academy.Data;
using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repos
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
