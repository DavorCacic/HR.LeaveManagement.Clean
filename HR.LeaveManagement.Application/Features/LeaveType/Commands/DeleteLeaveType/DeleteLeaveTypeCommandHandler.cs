using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    internal class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve to domain entity
            var leaveTypeToBeDeleted = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify that record exist
            if (leaveTypeToBeDeleted == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            // add to DB
            await _leaveTypeRepository.DeleteAsync(leaveTypeToBeDeleted);

            //return
            return Unit.Value;
        }
    }
}
