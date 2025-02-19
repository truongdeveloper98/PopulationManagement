using System.ComponentModel.DataAnnotations;
namespace SWECVI.ApplicationCore.ViewModels;

public class LoginDto
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; } = false;
    }
    
    public class LoginResult 
    {
        public string? Token { get; set; }
    }
}

