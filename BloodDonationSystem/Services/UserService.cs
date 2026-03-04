using BloodDonationSystem.DTOs.User;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BloodDonationSystem.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserDetailsDto>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDetailsDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException("User not found.");
            return MapToDto(user);
        }

        public async Task DisableUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException("User not found.");
            user.IsActive = false;
            await _userManager.UpdateAsync(user);
        }

        public async Task EnableUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException("User not found.");
            user.IsActive = true;
            await _userManager.UpdateAsync(user);
        }

        public async Task ChangeRoleAsync(ChangeRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId)
                ?? throw new KeyNotFoundException("User not found.");

            // Remove old role and add new one
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, dto.NewRole.ToString());

            user.Role = dto.NewRole;
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
                ?? throw new KeyNotFoundException("User not found.");
            await _userManager.DeleteAsync(user);
        }

        // ✅ مضاف — Get Profile
        public async Task<UserDetailsDto> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new KeyNotFoundException("User not found.");
            return MapToDto(user);
        }

        // ✅ مضاف — Update Profile
        public async Task<UserDetailsDto> UpdateProfileAsync(string userId, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new KeyNotFoundException("User not found.");

            user.FullName = dto.FullName;
            user.PhoneNumber = dto.PhoneNumber;
            user.BloodType = dto.BloodType;
            user.ProfilePicture = dto.ProfilePicture;

            await _userManager.UpdateAsync(user);
            return MapToDto(user);
        }

        private static UserDetailsDto MapToDto(ApplicationUser u) => new()
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email ?? "",
            PhoneNumber = u.PhoneNumber,
            BloodType = u.BloodType,
            Role = u.Role,
            IsActive = u.IsActive,
            CreatedAt = u.CreatedAt,
            ProfilePicture = u.ProfilePicture   // ✅ مضاف

        };

    }
}
