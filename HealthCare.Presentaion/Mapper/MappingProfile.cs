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
            CreateMap<RegisterUserVM, AppUser>().ForMember(u => u.PasswordHash, opt => opt.MapFrom(x => x.Password));
        }

    }
}
