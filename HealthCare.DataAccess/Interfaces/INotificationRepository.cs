using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllByUserId(string UserId);
        Task AddNotification(Notification notification);

    }
}
