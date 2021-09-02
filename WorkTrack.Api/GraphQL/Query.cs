using AutoMapper;
using HotChocolate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.DTOs;
using WorkTrack.Core.Entities;
using WorkTrack.Core.Interfaces;

namespace WorkTrack.Api.GraphQL
{
    public class Query
    {
        private readonly IMapper mapper;
        private readonly IRepository<WorkRecord> workRecordRepository;

        public Query(IRepository<WorkRecord> workRecordRepository,
            IMapper mapper)
        {
            this.workRecordRepository = workRecordRepository;
            this.mapper = mapper;
        }

        [GraphQLDescription("Gets work records.")]
        public async Task<IEnumerable<WorkRecordDto>> GetWorkRecord()
        {
            var workRecords = await workRecordRepository.GetAllAsync();
            if(workRecords == null)
            {
                return Enumerable.Empty<WorkRecordDto>();
            }

            return workRecords.Select(record => mapper.Map<WorkRecord, WorkRecordDto>(record));
        }
    }
}
