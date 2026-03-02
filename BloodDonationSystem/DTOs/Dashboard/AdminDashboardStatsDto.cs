namespace BloodDonationSystem.DTOs.Dashboard
{
    public class AdminDashboardStatsDto
    {
        public int TotalUsers { get; set; }
        public int TotalDonors { get; set; }
        public int TotalReceivers { get; set; }
        public int TotalDonations { get; set; }
        public int PendingDonations { get; set; }
        public int ApprovedDonations { get; set; }
        public int TotalBloodRequests { get; set; }
        public int PendingBloodRequests { get; set; }
        public int UrgentBloodRequests { get; set; }
        public int ActiveCampaigns { get; set; }
        public int TotalBlogPosts { get; set; }

    }
}
