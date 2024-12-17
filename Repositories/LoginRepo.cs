using Academy.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repos
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _context;

        public LoginRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateUser(string usernameOrEmail, string password)
        {
            var user = await _context.Registrations.FirstOrDefaultAsync(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail);

            if (user == null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true;
            }
            else
            {
                // If verification fails, rehash the password and update it in the database
                string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                user.Password = newHashedPassword;
                await _context.SaveChangesAsync();  // Save the updated password hash to the database

                return true;
            }
        }
    }
}
