using MediatR;
using System.Threading.Tasks;
using WorkTrack.Core.CommandModels;
using WorkTrack.Core.Entities;

namespace WorkTrack.Api.GraphQL
{
    public class Mutation
    {
        private readonly IMediator mediator;

        public Mutation(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<WorkRecord> AddWorkRecordAsync(CreateWorkRecordCommandModel input)
        {
            return await mediator.Send(input);
        }
    }
}
