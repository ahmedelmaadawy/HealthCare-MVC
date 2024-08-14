namespace HealthCare.BusinessLogic.ViewModels.TimeSlotVMs
{
    public class TimeSlotwithDoctorVM
    {
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public List<HealthCare.DataAccess.Models.TimeSlot> TimeSlots { get; set; } = new List<DataAccess.Models.TimeSlot>();
    }
}
