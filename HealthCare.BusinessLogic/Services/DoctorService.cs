using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.Doctor;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public DoctorService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Doctor doctor)
        {
            await _context.Doctors.Add(doctor);
            await _context.Compelete();
        }

        public async Task<List<DoctorToDisplayVM>> GetAll()
        {
            var doctors = await _context.Doctors.GetAll();

            var doctorsVM = _mapper.Map<List<DoctorToDisplayVM>>(doctors);
            return doctorsVM;
        }

        public async Task<Doctor> GetById(int id)
        {
            return await _context.Doctors.GetById(id);
        }

        public async Task Update(int Id, Doctor doctor)
        {
            var res = await _context.Doctors.GetAll();
            var doc = res.Where(d => d.Id == Id).FirstOrDefault();
            if (doc != null)
            {
                doc.FirstName = doctor.FirstName;
                doc.LastName = doctor.LastName;
                doc.Specialization = doctor.Specialization;
                doc.OfficeAddress = doctor.OfficeAddress;
                doc.ContactNumber = doctor.ContactNumber;
                _context.Doctors.Update(doctor);
                await _context.Compelete();
            }
        }
        public async Task Delete(int id)
        {
            _context.Doctors.Delete(id);
            await _context.Compelete();
        }
        public async Task AddTimeSlot(TimeSlot timeSlot)
        {
            await _context.TimeSlots.Add(timeSlot);
            await _context.Compelete();
        }
        public async Task DeleteTimeSlot(int id)
        {
            var ts = await _context.TimeSlots.GetById(id);
            _context.TimeSlots.Delete(ts);
            await _context.Compelete();
        }

    }
}
