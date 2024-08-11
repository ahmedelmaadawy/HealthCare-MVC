using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels
{
    public class RoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
