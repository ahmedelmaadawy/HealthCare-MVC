using System.ComponentModel.DataAnnotations;

namespace HealthCare.BusinessLogic.ViewModels.Doctor
{
    public class DoctorToDisplayVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string OfficeAddress { get; set; }

        public List<HealthCare.DataAccess.Models.TimeSlot> AvailableTimeSlots { get; set; }
    }
}
