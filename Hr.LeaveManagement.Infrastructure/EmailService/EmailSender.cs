﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Hr.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSetting _emailSetting { get; }
        public EmailSender(IOptions<EmailSetting> emaiilSetting)
        {
            _emailSetting = emaiilSetting.Value;

        }
        public Task<bool> SendEmailAsync(EmailMessage email)
        {
            var client= new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = client.SendEmailAsync(message);
            return response.ContinueWith(task => task.Result.StatusCode == System.Net.HttpStatusCode.OK);

        }
    }
}
