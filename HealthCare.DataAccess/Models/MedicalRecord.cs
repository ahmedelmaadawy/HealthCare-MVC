using System.ComponentModel.DataAnnotations;

namespace HealthCare.DataAccess.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }

        public DateTime Date { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Prescription { get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
