using HealthCare.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace HealthCare.Presentaion.ViewModels
{
    public class DoctorToDisplayVM
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Specialization { get; set; }
        [MaxLength(11)]
        public string ContactNumber { get; set; }
        public string OfficeAddress { get; set; }

        public List<TimeSlot> AvailableTimeSlots { get; set; }
    }
}
