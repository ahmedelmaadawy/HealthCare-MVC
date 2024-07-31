﻿namespace HealthCare.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IDoctorRepository Doctors { get; }

        int Compelete();

    }
}
