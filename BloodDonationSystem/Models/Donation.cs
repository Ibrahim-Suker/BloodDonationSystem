using BloodDonationSystem.Enums;

namespace BloodDonationSystem.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorId { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public DonationType Type { get; set; }
        public DonationStatus Status { get; set; } = DonationStatus.Pending;
        public DateTime DonationDate { get; set; } = DateTime.UtcNow;
        public string? ApprovedByAdminId { get; set; }

        // Navigation Properties
        public ApplicationUser Donor { get; set; } = null!;
        public ApplicationUser? ApprovedByAdmin { get; set; }

    }
}
