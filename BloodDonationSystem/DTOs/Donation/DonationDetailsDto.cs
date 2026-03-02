using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.Donation
{
    public class DonationDetailsDto
    {
        public int Id { get; set; }
        public string DonorId { get; set; } = string.Empty;
        public string DonorName { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public DonationType Type { get; set; }
        public DonationStatus Status { get; set; }
        public DateTime DonationDate { get; set; }
        public string? ApprovedByAdminId { get; set; }

    }
}
