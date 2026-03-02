using BloodDonationSystem.DTOs.Donation;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface IDonationService
    {
        Task<DonationDetailsDto> CreateDonationAsync(string donorId, CreateDonationDto dto);
        Task<List<DonationDetailsDto>> GetAllDonationsAsync();
        Task<List<DonationDetailsDto>> GetDonationsByDonorAsync(string donorId);
        Task<DonationDetailsDto> ApproveDonationAsync(int donationId, string adminId);
        Task<DonationDetailsDto> RejectDonationAsync(int donationId);

    }
}
