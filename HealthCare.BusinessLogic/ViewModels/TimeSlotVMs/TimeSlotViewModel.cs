namespace HealthCare.BusinessLogic.ViewModels.TimeSlotVMs
{
    public class TimeSlotViewModel
    {
        public int DoctorID { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
