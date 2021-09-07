using MediatR;
using System;
using WorkTrack.Core.Entities;

namespace WorkTrack.Core.CommandModels
{
    public record CreateWorkRecordCommandModel(DateTime Start, DateTime End, string Description)
        : IRequest<WorkRecord>;
}
