namespace BloodDonationSystem.DTOs.Auth
{
    public class RegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public BloodDonationSystem.Enums.BloodType BloodType { get; set; }
        public BloodDonationSystem.Enums.UserRole Role { get; set; }

    }
}
