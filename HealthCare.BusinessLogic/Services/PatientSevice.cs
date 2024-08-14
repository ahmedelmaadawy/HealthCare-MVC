using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Services
{
    public class PatientSevice : IPatientService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public PatientSevice(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Patient patient)
        {
            await _context.Patients.Add(patient);
            await _context.Compelete();
        }

        public async Task<List<PatientToDisplayVM>> GetAll()
        {
            var patients = await _context.Patients.GetAll();
            var patientsVM = _mapper.Map<List<PatientToDisplayVM>>(patients);
            return patientsVM;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var record = await _context.Patients.GetAll();
            return record.FirstOrDefault(e => e.Id == id);

        }

        public async Task Update(Patient patient)
        {
            var record = await _context.Patients.GetAll();
            var existingPatient = record.FirstOrDefault(e => e.Id == patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.Gender = patient.Gender;
                existingPatient.ContactNumber = patient.ContactNumber;
                existingPatient.Adderss = patient.Adderss;


                _context.Patients.Update(existingPatient);
                await _context.Compelete();
            }

        }

        public async Task Delete(int id)
        {
            var record = await _context.Patients.GetAll();
            var patient = record.FirstOrDefault(e => e.Id == id);
            if (patient != null)
            {

                _context.Patients.Delete(patient);
                await _context.Compelete();
            }
            else
            {
                throw new ArgumentException($"Patient with ID {id} does not exist.");
            }
        }

    }
}