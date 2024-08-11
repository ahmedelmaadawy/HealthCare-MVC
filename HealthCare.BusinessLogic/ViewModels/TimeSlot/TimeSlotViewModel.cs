using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.ViewModels.TimeSlot
{
    public class TimeSlotViewModel
    {
        public int DoctorID { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
