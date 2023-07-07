using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _mapper = mapper;
            _leaveTypeRepository = repository;
        }


        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //covert objects to DTOs
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO objects
            return data;
        }
    }
}
