using BloodDonationSystem.DTOs.Notification;
using BloodDonationSystem.Models;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendGlobalAsync(SendGlobalNotificationDto dto);
        Task SendToUserAsync(SendUserNotificationDto dto);
        Task SendByBloodTypeAsync(SendBloodTypeNotificationDto dto);
        Task<List<Notification>> GetUserNotificationsAsync(string userId);

    }
}
