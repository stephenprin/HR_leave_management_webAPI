using Hr.LeaveManagement.Infrastructure.EmailService;
using Hr.LeaveManagement.Infrastructure.Logging;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Models.Email;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hr.LeaveManagement.Infrastructure
{
    public static class InfrastructureSeviceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            {
               services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
                services.AddTransient<IEmailSender, EmailSender>();
                services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
                return services;
            }
        }
    }
}
