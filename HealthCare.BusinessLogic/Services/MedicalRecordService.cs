using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.MedicalRecord;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

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

        public async Task CreateMedicalRecord(AddingMedicalRecordVM model)
        {

            var record = _mapper.Map<MedicalRecord>(model);
            await _context.MedicalRecords.AddMedicalRecord(record);
            await _context.Compelete();
        }



        public async Task<MedicalRecordViewModel> GetMedicalRecordById(int id)
        {
            var record = await _context.MedicalRecords.GetMedicalRecordById(id);
            var result = _mapper.Map<MedicalRecordViewModel>(record);
            return result;
        }


        public async Task<List<MedicalRecordViewModel>> GetMedicalRecordsByDoctor(int doctorId)
        {
            var records = await _context.MedicalRecords.GetMedicalRecordsByDoctor(doctorId);
            var result = _mapper.Map<List<MedicalRecordViewModel>>(records);
            return result;
        }

        public async Task<List<MedicalRecordViewModel>> GetMedicalRecordsByPatient(int patientId)
        {
            var records = await _context.MedicalRecords.GetMedicalRecordsByPatient(patientId);
            var result = _mapper.Map<List<MedicalRecordViewModel>>(records);

            return result;
        }




    }
}
