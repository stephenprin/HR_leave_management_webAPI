using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Application.Contracts.Email
{
   public interface IEmailSender
    {
        Task<bool> SendEmailAsync(EmailMessage email);
    }
}
