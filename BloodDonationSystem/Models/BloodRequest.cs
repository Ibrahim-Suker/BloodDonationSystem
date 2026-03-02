using BloodDonationSystem.Enums;

namespace BloodDonationSystem.Models
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public string ReceiverId { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }
        public string HospitalName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public ApplicationUser Receiver { get; set; } = null!;

    }
}
