﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation: BaseEntity
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    //public Employee Employee { get; set; }
    //public int EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType? LeaveType { get; set; }
 
}
