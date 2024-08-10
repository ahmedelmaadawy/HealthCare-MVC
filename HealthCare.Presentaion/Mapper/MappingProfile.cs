using AutoMapper;
using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;

namespace HealthCare.Presentaion.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorToDisplayVM>().ForMember(d => d.FullName, opt => opt.MapFrom(x => string.Join(' ', x.FirstName, x.LastName)));
        //    CreateMap<MedicalRecord, MedicalRecordViewModel>().ForMember(d => d.DoctorName, opt => opt.MapFrom(x => string.Join(' ', x.Doctor.FirstName, x.Doctor.LastName)));
        //    CreateMap<MedicalRecord, MedicalRecordViewModel>().ForMember(d =>d.PatientName, opt => opt.MapFrom(x => string.Join(' ', x.Patient.FirstName, x.Patient.LastName)));
        }

    }
}
