using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels.Identity
{
    public class LoginUserVM
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
