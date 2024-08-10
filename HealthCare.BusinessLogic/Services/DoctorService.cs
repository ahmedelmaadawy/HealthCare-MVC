using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using HealthCare.DataAccess.Repository;
using HealthCare.Presentaion.ViewModels;
using System.Runtime.CompilerServices;

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
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.Compelete();
        }

        public List<DoctorToDisplayVM> GetAll()
        {
            var doctors = _context.Doctors.GetAll();

            var doctorsVM = _mapper.Map<List<DoctorToDisplayVM>>(doctors);
            return doctorsVM;
        }
        
        public Doctor GetById(int id)
        {
            return _context.Doctors.GetById(id);
        }

        public void Update(int Id, Doctor doctor)
        {
            var doc = _context.Doctors.GetAll().Where(d=>d.Id==Id).FirstOrDefault();
            if (doc != null)
            {
                doc.FirstName = doctor.FirstName;
                doc.LastName = doctor.LastName;
                doc.Specialization = doctor.Specialization;
                doc.OfficeAddress = doctor.OfficeAddress;
                doc.ContactNumber = doctor.ContactNumber;
                _context.Doctors.Update(doctor);
                _context.Compelete();
            }
        }
        public void Delete(int id)
        {
            _context.Doctors.Delete(id);
            _context.Compelete();
        }
        public void AddTimeSlot(TimeSlot timeSlot)
        {
            _context.TimeSlots.Add(timeSlot);
            _context.Compelete();
        }

    }
}
