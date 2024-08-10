using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels
{
    public class RegisterUserVM
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
