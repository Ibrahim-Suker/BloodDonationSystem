using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.Donation;
using BloodDonationSystem.Enums;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Services
{
    public class DonationService : IDonationService
    {
        private readonly ApplicationDbContext _context;

        public DonationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DonationDetailsDto> CreateDonationAsync(string donorId, CreateDonationDto dto)
        {
            var donation = new Donation
            {
                DonorId = donorId,
                BloodType = dto.BloodType,
                Type = dto.Type,
                DonationDate = dto.DonationDate,
                Status = DonationStatus.Pending
            };

            _context.Donations.Add(donation);
            await _context.SaveChangesAsync();

            return await GetDetailsDto(donation.Id);
        }

        public async Task<List<DonationDetailsDto>> GetAllDonationsAsync()
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Select(d => MapToDto(d))
                .ToListAsync();
        }

        public async Task<List<DonationDetailsDto>> GetDonationsByDonorAsync(string donorId)
        {
            return await _context.Donations
                .Include(d => d.Donor)
                .Where(d => d.DonorId == donorId)
                .Select(d => MapToDto(d))
                .ToListAsync();
        }

        public async Task<DonationDetailsDto> ApproveDonationAsync(int donationId, string adminId)
        {
            var donation = await _context.Donations.FindAsync(donationId)
                ?? throw new KeyNotFoundException("Donation not found");

            donation.Status = DonationStatus.Approved;
            donation.ApprovedByAdminId = adminId;
            await _context.SaveChangesAsync();

            return await GetDetailsDto(donationId);
        }

        public async Task<DonationDetailsDto> RejectDonationAsync(int donationId)
        {
            var donation = await _context.Donations.FindAsync(donationId)
                ?? throw new KeyNotFoundException("Donation not found");

            donation.Status = DonationStatus.Rejected;
            await _context.SaveChangesAsync();

            return await GetDetailsDto(donationId);
        }

        private async Task<DonationDetailsDto> GetDetailsDto(int id)
        {
            var d = await _context.Donations
                .Include(x => x.Donor)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Donation not found");

            return MapToDto(d);
        }

        private static DonationDetailsDto MapToDto(Donation d) => new()
        {
            Id = d.Id,
            DonorId = d.DonorId,
            DonorName = d.Donor?.FullName ?? "",
            BloodType = d.BloodType,
            Type = d.Type,
            Status = d.Status,
            DonationDate = d.DonationDate,
            ApprovedByAdminId = d.ApprovedByAdminId
        };
    }
}
