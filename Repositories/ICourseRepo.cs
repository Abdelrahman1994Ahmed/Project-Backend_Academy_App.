using Academy.Models;

namespace Academy.Repos
{
    public interface ICourseRepo
    {
        Task<IEnumerable<Course>> GetAll();
    }
}
