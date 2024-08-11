using HealthCare.BusinessLogic.ViewModels.MedicalRecord;
using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IMedicalRecordService
    {
        void CreateMedicalRecord(AddingMedicalRecordVM model);
        MedicalRecordViewModel GetMedicalRecordById(int id);
        List<MedicalRecordViewModel> GetMedicalRecordsByDoctor(int doctorId);
        List<MedicalRecordViewModel> GetMedicalRecordsByPatient(int patientId);
        
    }
}
