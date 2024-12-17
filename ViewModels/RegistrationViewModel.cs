using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academy.ViewModels
{
    public class RegistrationViewModel
    {
        public string Username { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Number { get; set; }

        [EmailAddress(ErrorMessage = "Invalid E-mail Address")]
        public string Email { get; set; }

        [MinLength(6,ErrorMessage = "Password should be at least 6 Chr/s")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
