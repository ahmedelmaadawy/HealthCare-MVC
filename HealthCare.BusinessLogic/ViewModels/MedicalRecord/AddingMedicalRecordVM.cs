namespace HealthCare.BusinessLogic.ViewModels.MedicalRecord
{
    public class AddingMedicalRecordVM
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public string Prescription { get; set; }
    }
}
