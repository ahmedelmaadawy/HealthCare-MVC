using HealthCare.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IUnitOfWork _context;

        public NotificationController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserNotifications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var notifications = await _context.Notifications.GetAllByUserId(userId);
            notifications = notifications.OrderByDescending(n => n.CreatedAt).ToList();


            return Json(notifications);
        }
    }
}
