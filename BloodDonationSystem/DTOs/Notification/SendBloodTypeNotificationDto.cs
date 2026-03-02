using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.Notification
{
    public class SendBloodTypeNotificationDto
    {
        public BloodType BloodType { get; set; }
        public string Message { get; set; } = string.Empty;

    }
}
