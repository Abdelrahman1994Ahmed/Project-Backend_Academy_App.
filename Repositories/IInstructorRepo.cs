using Academy.Models;
using Academy.ViewModels;

namespace Academy.Repos
{
    public interface IInstructorRepo
    {
        Task CreateInstructor(InstructorViewModel instructorViewModel);
        Task<bool> EditInstructor(InstructorViewModel instructorViewModel, int Id);
        Task<Instructor> GetInstructorId(int Id);
        Task<IEnumerable<Instructor>> GetAll();
        Task DeletInst(Instructor instructor);
    }
}
