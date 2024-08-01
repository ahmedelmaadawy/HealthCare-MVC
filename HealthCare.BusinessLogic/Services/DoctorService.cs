using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;

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
    }
}
