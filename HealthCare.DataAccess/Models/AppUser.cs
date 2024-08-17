using Microsoft.AspNetCore.Identity;

namespace HealthCare.DataAccess.Models
{
    public class AppUser : IdentityUser
    {
        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
