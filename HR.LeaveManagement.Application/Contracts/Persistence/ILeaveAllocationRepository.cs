using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        Task<LeaveAllocation> GeLeaveAllocationWithDetails(int id);
        Task<bool> AllocationExits(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
        Task <LeaveAllocation> GetUserLeaveAllocation(string userId, int leaveTypeId);
    }
}
