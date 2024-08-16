using AutoMapper;
using HealthCare.BusinessLogic.ViewModels.Doctor;
using HealthCare.BusinessLogic.ViewModels.Identity;
using HealthCare.BusinessLogic.ViewModels.MedicalRecord;
using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Models;

namespace HealthCare.Presentaion.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorToDisplayVM>().ForMember(d => d.FullName, opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));
            CreateMap<RegisterUserVM, AppUser>().ForMember(u => u.PasswordHash, opt => opt.MapFrom(x => x.Password));
            CreateMap<Patient, PatientToDisplayVM>();
            CreateMap<PatientToCreateVM, Patient>();
            CreateMap<PatientToEditVM, Patient>();
            CreateMap<Patient, PatientToEditVM>();
            CreateMap<AddingMedicalRecordVM, MedicalRecord>().ForMember(m => m.Date, opt => opt.MapFrom(x => x.AppointmentDate));
            CreateMap<MedicalRecord, MedicalRecordViewModel>().ForMember(m => m.AppointmentDate, opt => opt.MapFrom(x => x.Date))
                .ForMember(vm => vm.DoctorName, opt => opt.MapFrom(x => string.Join(' ', x.Doctor.FirstName, x.Doctor.LastName)))
                .ForMember(vm => vm.PatientName, opt => opt.MapFrom(x => string.Join(' ', x.Patient.FirstName, x.Patient.LastName)));

        }


    }
}
