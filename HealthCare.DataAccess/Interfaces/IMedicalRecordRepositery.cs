using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IMedicalRecordRepositery
    {
        void AddMedicalRecord(MedicalRecord record);
        MedicalRecord GetMedicalRecordById(int id);
        List<MedicalRecord> GetMedicalRecordsByDoctor(int doctorId);
        List<MedicalRecord> GetMedicalRecordsByPatient(int patientId);
    }
}
