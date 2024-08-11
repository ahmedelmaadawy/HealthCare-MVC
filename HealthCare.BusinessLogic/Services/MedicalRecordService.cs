using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Models;
using HealthCare.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HealthCare.BusinessLogic.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public MedicalRecordService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateMedicalRecord(AddingMedicalRecordVM model)
        {
            var record = new MedicalRecord
            {
                DoctorID = model.DoctorId,
                PatientID = model.PatientId,
                Date = model.AppointmentDate,
                Description = model.Description,
                Prescription=model.Prescription
                
            };
             _context.MedicalRecords.AddMedicalRecord(record);
            _context.Compelete();
        }

     

        public MedicalRecordViewModel GetMedicalRecordById(int id)
        {
            var record = _context.MedicalRecords.GetMedicalRecordById(id);
            return new MedicalRecordViewModel
            {
                Id = record.Id,
                DoctorId = record.DoctorID,
                PatientId = record.PatientID,
                AppointmentDate = record.Date,
                Description = record.Description,
                Prescription=record.Prescription,
                DoctorName = record.Doctor.FirstName,
                PatientName = record.Patient.FirstName
            };
        }
       

        public List<MedicalRecordViewModel> GetMedicalRecordsByDoctor(int doctorId)
        {
            return _context.MedicalRecords.GetMedicalRecordsByDoctor(doctorId)
                .Select(r => new MedicalRecordViewModel
                {
                    Id = r.Id,
                    PatientName = r.Patient.FirstName,
                    AppointmentDate = r.Date,
                    Description = r.Description,
                    Prescription=r.Prescription
                }).ToList();
        }

        public List<MedicalRecordViewModel> GetMedicalRecordsByPatient(int patientId)
        {
            return _context.MedicalRecords.GetMedicalRecordsByPatient(patientId)
                .Select(r => new MedicalRecordViewModel
                {
                    Id = r.Id,
                    DoctorName = r.Doctor.FirstName,
                    AppointmentDate = r.Date,
                    Description = r.Description,
                    Prescription=r.Prescription
                }).ToList();
        }

      

     
    }
}
