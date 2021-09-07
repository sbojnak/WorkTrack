using HotChocolate;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.Entities;

namespace WorkTrack.Api.GraphQL
{
    public class Query
    {
        private readonly IMediator mediator;

        public Query(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [GraphQLDescription("Gets work records.")]
        public async Task<IEnumerable<WorkRecord>> GetWorkRecordsAsync()
        {
            //mediator.Send()
            //if (workRecords == null)
            //{
            //    return Queryable.AsQueryable(Enumerable.Empty<WorkRecord>());
            //}

            //return workRecords;
            throw new System.Exception();
        }
    }
}
