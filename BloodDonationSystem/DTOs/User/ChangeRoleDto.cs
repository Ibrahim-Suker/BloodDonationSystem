using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.User
{
    public class ChangeRoleDto
    {
        public string UserId { get; set; } = string.Empty;
        public UserRole NewRole { get; set; }

    }
}
