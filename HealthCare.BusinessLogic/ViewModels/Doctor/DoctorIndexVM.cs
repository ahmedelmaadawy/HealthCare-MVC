using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.ViewModels.Doctor
{
    public class DoctorIndexVM
    {
        public List<DoctorToDisplayVM> Doctors { get; set; }
        public List<string> Specializations { get; set; }
        public List<string> OfficeAddresses { get; set; }
        public string CurrentSpecialization { get; set; }
        public string CurrentOfficeAddress { get; set; }
    }
}
