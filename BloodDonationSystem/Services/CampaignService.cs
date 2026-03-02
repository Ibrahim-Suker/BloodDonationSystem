using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.Campaign;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BloodDonationSystem.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ApplicationDbContext _context;

        public CampaignService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CampaignDetailsDto> CreateCampaignAsync(CreateCampaignDto dto)
        {
            var campaign = new Campaign
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = true
            };

            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();
            return MapToDto(campaign);
        }

        public async Task<CampaignDetailsDto> UpdateCampaignAsync(int id, UpdateCampaignDto dto)
        {
            var campaign = await _context.Campaigns.FindAsync(id)
                ?? throw new KeyNotFoundException("Campaign not found");

            campaign.Title = dto.Title;
            campaign.Description = dto.Description;
            campaign.Location = dto.Location;
            campaign.Latitude = dto.Latitude;
            campaign.Longitude = dto.Longitude;
            campaign.StartDate = dto.StartDate;
            campaign.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();
            return MapToDto(campaign);
        }

        public async Task DeleteCampaignAsync(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id)
                ?? throw new KeyNotFoundException("Campaign not found");

            _context.Campaigns.Remove(campaign);
            await _context.SaveChangesAsync();
        }

        public async Task<CampaignDetailsDto> ToggleCampaignAsync(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id)
                ?? throw new KeyNotFoundException("Campaign not found");

            campaign.IsActive = !campaign.IsActive;
            await _context.SaveChangesAsync();
            return MapToDto(campaign);
        }

        public async Task<List<CampaignDetailsDto>> GetAllCampaignsAsync()
        {
            return await _context.Campaigns
                .Select(c => MapToDto(c))
                .ToListAsync();
        }

        private static CampaignDetailsDto MapToDto(Campaign c) => new()
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Location = c.Location,
            Latitude = c.Latitude,
            Longitude = c.Longitude,
            StartDate = c.StartDate,
            EndDate = c.EndDate,
            IsActive = c.IsActive
        };
    }
}
