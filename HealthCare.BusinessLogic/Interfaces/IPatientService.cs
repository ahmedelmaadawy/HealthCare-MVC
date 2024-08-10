using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IPatientService
    {
        List<PatientToDisplayVM> GetAll();
        PatientToDisplayVM GetPatientById(int id);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int id);
    }
}
