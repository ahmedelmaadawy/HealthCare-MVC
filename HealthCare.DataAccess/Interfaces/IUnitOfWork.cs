namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        ITimeSlotRepository TimeSlots { get; }
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }

        IMedicalRecordRepositery MedicalRecords { get; }
        int Compelete();

    }
}
