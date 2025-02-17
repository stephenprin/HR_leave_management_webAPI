using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceSeviceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfigureOptions configureOptions)
        {
            services.AddDbContext<HrDatabaseContext>(options =>
            {
                options.UseSqlServer();
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));
            services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));
          return services;
        }
    }
}
