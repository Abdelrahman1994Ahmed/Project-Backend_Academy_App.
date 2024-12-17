using Academy.Data;
using Academy.Models;

namespace Academy.Repos
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAll();
    }
}
