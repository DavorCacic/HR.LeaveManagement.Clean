using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _mapper = mapper;
            _leaveTypeRepository = repository;
        }


        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //check
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(leaveType), request.Id);
            }

            //covert objects to DTOs
            var data = _mapper.Map<LeaveTypeDetailDto>(leaveType);

            //return list of DTO objects
            return data;
        }
    }
}
