using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Repos
{
    public interface IRegistrationRepo
    {
        Task Create(Registration registration);

        Task<IEnumerable<Registration>> GetAll();

    }
}
