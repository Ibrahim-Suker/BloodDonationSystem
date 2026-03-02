using BloodDonationSystem.Enums;

namespace BloodDonationSystem.DTOs.BloodRequest
{
    public class BloodRequestDetailsDto
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverId { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public int Quantity { get; set; }
        public string HospitalName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
