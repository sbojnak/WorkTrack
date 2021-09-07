using HotChocolate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.Entities;
using WorkTrack.Core.QueryModels;

namespace WorkTrack.Api.GraphQL
{
    public class Query
    {
        private readonly IMediator mediator;

        public Query(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //TODO: change to IQueryable
        [GraphQLDescription("Gets work records.")]
        public async Task<IEnumerable<WorkRecord>> GetWorkRecordsAsync()
        {
            var queryModel = new GetWorkRecordsQueryModel(Id: null, Start: null, End: null, Description: null);
            var workRecords = await mediator.Send(queryModel);
            if (workRecords == null)
            {
                return Queryable.AsQueryable(Enumerable.Empty<WorkRecord>());
            }

            return workRecords;
        }
    }
}
