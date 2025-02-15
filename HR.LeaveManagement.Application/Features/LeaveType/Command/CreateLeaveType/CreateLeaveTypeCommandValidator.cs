using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository) { 
          RuleFor(p=> p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
      RuleFor(p => p.DefaultDays) 
.LessThan(100).WithMessage("{PropertyName} cannot exceed 100") 
.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q.Name)
                .MustAsync(LeaveUniqueName).WithMessage("{PropertyName} must be unique");

            _leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> LeaveUniqueName(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeNameUnique(command.Name);
        }
    }
}
