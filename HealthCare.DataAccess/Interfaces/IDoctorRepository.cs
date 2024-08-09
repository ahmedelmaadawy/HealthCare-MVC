using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IDoctorRepository
    {

        public void Add(Doctor doctor);
        public List<Doctor> GetAll();

        public Doctor GetById(int id);
        public void Update(Doctor doctor);
        void Delete(int id);

    }
}
