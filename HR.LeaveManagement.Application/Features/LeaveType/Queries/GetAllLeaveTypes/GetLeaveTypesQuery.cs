using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    //public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    //{

    //}

    //since this class will not be changed upon instatioation, it could be recort (imutable class)
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
