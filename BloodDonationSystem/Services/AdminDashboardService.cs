using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.Dashboard;
using BloodDonationSystem.Enums;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardStatsDto> GetStatisticsAsync()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalDonors = await _context.Users.CountAsync(u => u.Role == UserRole.Donor);
            var totalReceivers = await _context.Users.CountAsync(u => u.Role == UserRole.Receiver);

            var totalDonations = await _context.Donations.CountAsync();
            var pendingDonations = await _context.Donations.CountAsync(d => d.Status == DonationStatus.Pending);
            var approvedDonations = await _context.Donations.CountAsync(d => d.Status == DonationStatus.Approved);

            var totalRequests = await _context.BloodRequests.CountAsync();
            var pendingRequests = await _context.BloodRequests.CountAsync(r => r.Status == RequestStatus.Pending);
            var urgentRequests = await _context.BloodRequests.CountAsync(r => r.IsUrgent && r.Status == RequestStatus.Pending);

            var activeCampaigns = await _context.Campaigns.CountAsync(c => c.IsActive);
            var totalBlogPosts = await _context.BlogPosts.CountAsync();

            return new AdminDashboardStatsDto
            {
                TotalUsers = totalUsers,
                TotalDonors = totalDonors,
                TotalReceivers = totalReceivers,
                TotalDonations = totalDonations,
                PendingDonations = pendingDonations,
                ApprovedDonations = approvedDonations,
                TotalBloodRequests = totalRequests,
                PendingBloodRequests = pendingRequests,
                UrgentBloodRequests = urgentRequests,
                ActiveCampaigns = activeCampaigns,
                TotalBlogPosts = totalBlogPosts
            };
        }
    }
}
