using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WorkTrack.Core.CommandModels;
using WorkTrack.Core.Entities;
using WorkTrack.Infrastructure;

namespace WorkTrack.Logic.CommandHandlers
{
    internal class CreateWorkRecordCommandHandler : IRequestHandler<CreateWorkRecordCommandModel, WorkRecord>
    {
        private readonly WorkTrackDbContext workTrackDbContext;

        public CreateWorkRecordCommandHandler(WorkTrackDbContext workTrackDbContext)
        {
            this.workTrackDbContext = workTrackDbContext;
        }

        public async Task<WorkRecord> Handle(CreateWorkRecordCommandModel request, CancellationToken cancellationToken)
        {
            var result = workTrackDbContext.WorkRecords.Add(new WorkRecord
            {
                Start = request.Start,
                End = request.End,
                Description = request.Description
            });
            await workTrackDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
