namespace HealthCare.BusinessLogic.ViewModels.Patient
{
    public class PatientToDisplayVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Adderss { get; set; }
    }
}
