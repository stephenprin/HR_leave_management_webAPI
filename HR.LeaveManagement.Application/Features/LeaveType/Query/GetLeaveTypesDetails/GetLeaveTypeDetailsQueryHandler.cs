﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exeptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Query.GetLeaveTypesDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {

        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
           var leaveType = await _leaveTypeRepository.GetByIdAsync(request.id);
            if (leaveType == null) { 
            throw new NotFoundException(nameof(LeaveType), request.id);
            }
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);
            return data;
        }
    }
}
