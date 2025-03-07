﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExits(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId
            && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public async Task<LeaveAllocation> GeLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation= await _context.LeaveAllocations.Include(x => x.LeaveType).FirstOrDefaultAsync(x=>x.Id==id);
            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocation = await _context.LeaveAllocations.Include(x => x.LeaveType).ToListAsync();
            return leaveAllocation;
        }


        public async Task<LeaveAllocation> GetUserLeaveAllocation(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(x=>x.EmployeeId== userId && x.LeaveTypeId== leaveTypeId);

        }
    }
}
