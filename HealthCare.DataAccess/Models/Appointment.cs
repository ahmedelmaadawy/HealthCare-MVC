using HealthCare.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.DataAccess.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public AppointmentStatus? Status { get; set; }


        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
