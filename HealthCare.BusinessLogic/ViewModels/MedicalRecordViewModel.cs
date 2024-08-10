using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.ViewModels
{
    public class MedicalRecordViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
        public string Prescription { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
