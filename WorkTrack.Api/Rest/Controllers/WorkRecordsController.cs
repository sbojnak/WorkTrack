using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.DTOs;
using WorkTrack.Core.Entities;
using WorkTrack.Core.Interfaces;

namespace WorkTrack.Api.Rest.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkRecordsController : ControllerBase
    {
        private readonly ILogger<WorkRecordsController> logger;
        private readonly IMapper mapper;
        private readonly IRepository<WorkRecord> workRecordRepository;

        public WorkRecordsController(ILogger<WorkRecordsController> logger,
            IRepository<WorkRecord> workRecordRepository,
            IMapper mapper)
        {
            this.logger = logger;
            this.workRecordRepository = workRecordRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkRecordDto>>> Get()
        {
            var records = await workRecordRepository.GetAllAsync();
            if(records == null)
            {
                //throw exception
            }
            var recordDtos = records.Select(record => mapper.Map<WorkRecord, WorkRecordDto>(record));
            return Ok(recordDtos);
        }

        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<WorkRecordDto>> GetById(int id)
        {
            var record = await workRecordRepository.GetByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WorkRecord, WorkRecordDto>(record));
        }

        [HttpPost]
        public async Task<ActionResult<WorkRecordDto>> Create(WorkRecordDto newWorkRecordDto)
        {
            WorkRecord newWorkRecord;
            try
            {
                newWorkRecord = mapper.Map<WorkRecordDto, WorkRecord>(newWorkRecordDto);
                await workRecordRepository.CreateAsync(newWorkRecord);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetById), new { id = newWorkRecord.Id }, 
                mapper.Map<WorkRecord, WorkRecordDto>(newWorkRecord));
        }
    }
}
