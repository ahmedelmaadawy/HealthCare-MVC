using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels.Identity
{
    public class RoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
