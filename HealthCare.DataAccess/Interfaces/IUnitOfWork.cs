namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IDoctorRepository Doctors { get; }

        int Compelete();

    }
}
