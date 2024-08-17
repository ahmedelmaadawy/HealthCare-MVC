using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface INotificationService
    {
        Task BookAppointmentNotifications(Appointment appointment);
        Task<List<Notification>> GetNotificationListByUser(string UserId);
    }
}
