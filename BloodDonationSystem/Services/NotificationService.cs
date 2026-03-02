using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.Notification;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendGlobalAsync(SendGlobalNotificationDto dto)
        {
            // UserId = null means global → sent to all users
            var notification = new Notification
            {
                Message = dto.Message,
                UserId = null,
                BloodType = null
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task SendToUserAsync(SendUserNotificationDto dto)
        {
            var notification = new Notification
            {
                Message = dto.Message,
                UserId = dto.UserId,
                BloodType = null
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task SendByBloodTypeAsync(SendBloodTypeNotificationDto dto)
        {
            var notification = new Notification
            {
                Message = dto.Message,
                UserId = null,
                BloodType = dto.BloodType
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Notification>> GetUserNotificationsAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return new List<Notification>();

            // Return notifications that are:
            // 1. Sent directly to this user
            // 2. Global (UserId == null and BloodType == null)
            // 3. Matching the user's blood type
            return await _context.Notifications
                .Where(n =>
                    n.UserId == userId ||
                    (n.UserId == null && n.BloodType == null) ||
                    (n.UserId == null && n.BloodType == user.BloodType))
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }
}
