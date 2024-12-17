using Academy.Models;

namespace Academy.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Registration> registrations { get; set; }

    }
}
