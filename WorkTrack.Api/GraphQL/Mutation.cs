using System.Threading.Tasks;
using WorkTrack.Api.Models;
using WorkTrack.Core.Entities;
using WorkTrack.Core.Interfaces;

namespace WorkTrack.Api.GraphQL
{
    public class Mutation
    {
        private readonly IRepository<WorkRecord> workRecordRepository;

        public Mutation(IRepository<WorkRecord> workRecordRepository)
        {
            this.workRecordRepository = workRecordRepository;
        }

        public async Task<AddWorkRecordPayload> AddWorkRecordAsync(AddWorkRecordInput input)
        {
            var newWorkRecord = new WorkRecord
            {
                Start = input.Start,
                End = input.End,
                Description = input.Description
            };

            await workRecordRepository.CreateAsync(newWorkRecord);
            return new AddWorkRecordPayload(newWorkRecord);
        }
    }
}
