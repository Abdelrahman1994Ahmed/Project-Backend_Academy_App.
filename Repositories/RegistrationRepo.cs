using Academy.Data;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Academy.Repos
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly AppDbContext _context;

        public RegistrationRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Registration registration)
        {
            _context.Add(registration);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
            return await _context.Registrations.ToListAsync();
        }

    }
}
