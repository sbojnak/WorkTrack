using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkTrack.Core.Entities;

namespace WorkTrack.Core.QueryModels
{
    public record GetWorkRecordsQueryModel(int? Id, DateTime? Start, DateTime? End, string Description)
        : IRequest<IEnumerable<WorkRecord>>;
}
