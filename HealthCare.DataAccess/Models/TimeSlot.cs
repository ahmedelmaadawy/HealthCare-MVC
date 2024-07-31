namespace HealthCare.DataAccess.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int DoctorID { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; }

        public virtual Doctor? Doctor { get; set; }
    }
}
