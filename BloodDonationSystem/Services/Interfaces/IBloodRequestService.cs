using BloodDonationSystem.DTOs.BloodRequest;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface IBloodRequestService
    {
        Task<BloodRequestDetailsDto> CreateRequestAsync(string receiverId, CreateBloodRequestDto dto);
        Task<List<BloodRequestDetailsDto>> GetAllRequestsAsync();
        Task<List<BloodRequestDetailsDto>> GetRequestsByReceiverAsync(string receiverId);
        Task<BloodRequestDetailsDto> ChangeStatusAsync(int requestId, UpdateBloodRequestStatusDto dto);
        Task DeleteRequestAsync(int requestId);

    }
}
