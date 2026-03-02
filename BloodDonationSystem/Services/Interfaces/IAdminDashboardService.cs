using BloodDonationSystem.DTOs.Dashboard;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardStatsDto> GetStatisticsAsync();

    }
}
