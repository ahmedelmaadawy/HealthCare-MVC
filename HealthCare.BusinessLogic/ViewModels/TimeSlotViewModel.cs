using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.ViewModels
{
    public class TimeSlotViewModel
    {
        public int DoctorID { get; set; }
        [FutureDate(ErrorMessage = "Start Time must be today or a future date.")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateTime = (DateTime)value;

            if (dateTime.Date < DateTime.Today)
            {
                return new ValidationResult("The date must be today or in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
