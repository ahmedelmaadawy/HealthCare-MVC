namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }

        int Compelete();

    }
}
