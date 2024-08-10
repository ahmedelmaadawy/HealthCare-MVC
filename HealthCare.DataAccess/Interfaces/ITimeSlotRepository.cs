using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Interfaces
{
    public interface ITimeSlotRepository
    {
        void Add(TimeSlot timeSlot);
    }
}
