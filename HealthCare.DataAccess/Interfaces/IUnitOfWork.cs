namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITimeSlotRepository TimeSlots { get; }

        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }

        int Compelete();

    }
}
