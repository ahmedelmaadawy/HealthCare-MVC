using System.ComponentModel.DataAnnotations;

namespace HealthCare.Presentaion.ViewModels
{
    public class DoctorToDisplayVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string OfficeAddress { get; set; }
    }
}
