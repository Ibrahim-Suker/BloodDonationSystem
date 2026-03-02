using BloodDonationSystem.Enums;

namespace BloodDonationSystem.Models
{
    public class Notification
    {

        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? UserId { get; set; }           // null = global
        public BloodType? BloodType { get; set; }     // null = all blood types
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public ApplicationUser? User { get; set; }

    }
}
