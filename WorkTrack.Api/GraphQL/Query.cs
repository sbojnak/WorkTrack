using HotChocolate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.Entities;
using WorkTrack.Core.Interfaces;

namespace WorkTrack.Api.GraphQL
{
    public class Query
    {
        private readonly IRepository<WorkRecord> workRecordRepository;

        public Query(IRepository<WorkRecord> workRecordRepository)
        {
            this.workRecordRepository = workRecordRepository;
        }

        [GraphQLDescription("Gets work records.")]
        public async Task<IEnumerable<WorkRecord>> GetWorkRecordsAsync()
        {
            var workRecords = await workRecordRepository.GetAllAsync();
            if(workRecords == null)
            {
                return Enumerable.Empty<WorkRecord>();
            }

            return workRecords;
        }
    }
}
