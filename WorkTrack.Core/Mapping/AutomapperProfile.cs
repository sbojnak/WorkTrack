using AutoMapper;
using WorkTrack.Core.DTOs;
using WorkTrack.Core.Entities;

namespace WorkTrack.Core.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<WorkRecord, WorkRecordDto>().ReverseMap();
        }
    }
}
