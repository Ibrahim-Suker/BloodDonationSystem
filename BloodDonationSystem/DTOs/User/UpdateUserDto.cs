namespace BloodDonationSystem.DTOs.User
{
    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public BloodDonationSystem.Enums.BloodType BloodType { get; set; }

    }
}
