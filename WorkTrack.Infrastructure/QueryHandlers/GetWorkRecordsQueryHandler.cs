using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkTrack.Core.Entities;
using WorkTrack.Core.QueryModels;
using WorkTrack.Infrastructure;

namespace WorkTrack.Logic.QueryHandlers
{
    internal class GetWorkRecordsQueryHandler : IRequestHandler<GetWorkRecordsQueryModel, IEnumerable<WorkRecord>>
    {
        private readonly WorkTrackDbContext workTrackDbContext;

        public GetWorkRecordsQueryHandler(WorkTrackDbContext workTrackDbContext)
        {
            this.workTrackDbContext = workTrackDbContext;
        }

        public async Task<IEnumerable<WorkRecord>> Handle(GetWorkRecordsQueryModel request, CancellationToken cancellationToken)
        {
            return await workTrackDbContext.WorkRecords
                .Where(workRecord => (request.Id == null || request.Id == workRecord.Id)
                                    && (request.Start == null || request.Start == workRecord.Start)
                                    && (request.End == null || request.End == workRecord.End)
                                    && (request.Description == null || request.Description == workRecord.Description))
                .ToListAsync();
        }
    }
}
