using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.User
{
    public class UserDetailsDto
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public BloodType BloodType { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // ✅ مضاف
        public string? ProfilePicture { get; set; }

    }
}
