using Academy.Data;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Academy.Repos
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext _context;

        public InstructorRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateInstructor(InstructorViewModel instructorViewModel)
        {

            Instructor newInst = new Instructor()
            {
                Name = instructorViewModel.Name,
                ImgURL = instructorViewModel.ImgURL,
                Salary = instructorViewModel.Salary,
                Address = instructorViewModel.Address,
                DepId = instructorViewModel.DepId,
                CourseId = instructorViewModel.CourseId,
            };
            await _context.Instructors.AddAsync(newInst);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditInstructor(InstructorViewModel instructorViewModel, int Id)
        {
            Instructor curInst = await GetInstructorId(Id);
            if (curInst == null)
            {
                return false;
            }

            curInst.Name = instructorViewModel.Name;
            curInst.ImgURL = instructorViewModel.ImgURL;
            curInst.Salary = instructorViewModel.Salary;
            curInst.Address = instructorViewModel.Address;
            curInst.DepId = instructorViewModel.DepId;
            curInst.CourseId = instructorViewModel.CourseId;

            _context.Instructors.Update(curInst);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Instructor> GetInstructorId(int Id)
        {
            return await _context.Instructors.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _context.Instructors.Include(x => x.Department).Include(x => x.Course).ToListAsync();
        }

        public async Task DeletInst(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }
    }
}
