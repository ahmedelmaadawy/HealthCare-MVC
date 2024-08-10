using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IPatientRepository
    {
        public void Add(Patient patient);
        public List<Patient> GetAll();
        void Update(Patient patient);  // New method for updating
        void Delete(Patient patient);  // New method for deleting
    }
}
