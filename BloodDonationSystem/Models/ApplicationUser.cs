using BloodDonationSystem.Enums;
using Microsoft.AspNetCore.Identity;

namespace BloodDonationSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ مضاف
        public string? ProfilePicture { get; set; }


        // Navigation Properties
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<BloodRequest> BloodRequests { get; set; } = new List<BloodRequest>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    }
}
