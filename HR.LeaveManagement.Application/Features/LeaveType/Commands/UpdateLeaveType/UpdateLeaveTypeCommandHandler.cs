using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private IMapper _mapper;
        private ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
                _mapper = mapper;
                _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // TODO validate data

            // convert data to domain entity
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            //add to DB
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            //return
            return Unit.Value;
        }
    }
}
