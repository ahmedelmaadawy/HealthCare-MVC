using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels.Patient
{
    public class PatientToCreateVM
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        public string? Adderss { get; set; }
    }
}
