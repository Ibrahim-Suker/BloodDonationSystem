using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.Donation
{
    public class CreateDonationDto
    {
        public BloodType BloodType { get; set; }
        public DonationType Type { get; set; }
        public DateTime DonationDate { get; set; }

    }
}
