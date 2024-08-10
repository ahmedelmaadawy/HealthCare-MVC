using System.ComponentModel.DataAnnotations;

namespace HealthCare.DataAccess.Models
{
    public class Patient
    {
        public int Id { get; set; }
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

        public virtual List<Appointment>? Appointments { get; set; }
        public virtual List<MedicalRecord>? MedicalReccords { get; set; }
        public object Address { get; set; }
    }
}
