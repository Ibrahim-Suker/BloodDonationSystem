using BloodDonationSystem.Data;
using BloodDonationSystem.DTOs.BloodRequest;
using BloodDonationSystem.Models;
using BloodDonationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Services
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly ApplicationDbContext _context;

        public BloodRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BloodRequestDetailsDto> CreateRequestAsync(string receiverId, CreateBloodRequestDto dto)
        {
            var request = new BloodRequest
            {
                ReceiverId = receiverId,
                BloodType = dto.BloodType,
                Quantity = dto.Quantity,
                HospitalName = dto.HospitalName,
                City = dto.City,
                IsUrgent = dto.IsUrgent
            };

            _context.BloodRequests.Add(request);
            await _context.SaveChangesAsync();

            return await GetDetailsDto(request.Id);
        }

        public async Task<List<BloodRequestDetailsDto>> GetAllRequestsAsync()
        {
            return await _context.BloodRequests
                .Include(r => r.Receiver)
                .Select(r => MapToDto(r))
                .ToListAsync();
        }

        public async Task<List<BloodRequestDetailsDto>> GetRequestsByReceiverAsync(string receiverId)
        {
            return await _context.BloodRequests
                .Include(r => r.Receiver)
                .Where(r => r.ReceiverId == receiverId)
                .Select(r => MapToDto(r))
                .ToListAsync();
        }

        public async Task<BloodRequestDetailsDto> ChangeStatusAsync(int requestId, UpdateBloodRequestStatusDto dto)
        {
            var request = await _context.BloodRequests.FindAsync(requestId)
                ?? throw new KeyNotFoundException("Blood request not found");

            request.Status = dto.Status;
            await _context.SaveChangesAsync();

            return await GetDetailsDto(requestId);
        }

        public async Task DeleteRequestAsync(int requestId)
        {
            var request = await _context.BloodRequests.FindAsync(requestId)
                ?? throw new KeyNotFoundException("Blood request not found");

            _context.BloodRequests.Remove(request);
            await _context.SaveChangesAsync();
        }

        private async Task<BloodRequestDetailsDto> GetDetailsDto(int id)
        {
            var r = await _context.BloodRequests
                .Include(x => x.Receiver)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new KeyNotFoundException("Blood request not found");

            return MapToDto(r);
        }

        private static BloodRequestDetailsDto MapToDto(BloodRequest r) => new()
        {
            Id = r.Id,
            ReceiverId = r.ReceiverId,
            ReceiverName = r.Receiver?.FullName ?? "",
            BloodType = r.BloodType,
            Quantity = r.Quantity,
            HospitalName = r.HospitalName,
            City = r.City,
            IsUrgent = r.IsUrgent,
            Status = r.Status,
            CreatedAt = r.CreatedAt
        };
    }
}
