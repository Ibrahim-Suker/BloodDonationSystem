using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.BloodRequest
{
    public class CreateBloodRequestDto
    {
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }
        public string HospitalName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }

    }
}
