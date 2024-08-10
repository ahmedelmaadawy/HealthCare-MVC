namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IDoctorRepository Doctors { get; }
        IMedicalRecordRepositery MedicalRecords { get; }
        int Compelete();

    }
}
