using BloodDonationSystem.DTOs.User;

namespace BloodDonationSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDetailsDto>> GetAllUsersAsync();
        Task<UserDetailsDto> GetUserByIdAsync(string id);
        Task DisableUserAsync(string id);
        Task EnableUserAsync(string id);
        Task ChangeRoleAsync(ChangeRoleDto dto);
        Task DeleteUserAsync(string id);

    }
}
