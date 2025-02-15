using System.ComponentModel.DataAnnotations.Schema;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest: BaseEntity
{
    public DateTime? StartDate;
    public DateTime? EndDate;
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public bool? Cancelled { get; set; }
    public bool? Approved { get; set; }  
    public string RequestingEmployeeId { get; set; }= string.Empty;
}
