using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Api.Models;
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
        private readonly IRepository<WorkRecord> workRecordRepository;

        public WorkRecordsController(ILogger<WorkRecordsController> logger,
            IRepository<WorkRecord> workRecordRepository)
        {
            this.logger = logger;
            this.workRecordRepository = workRecordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkRecord>>> Get()
        {
            var records = await workRecordRepository.GetAllAsync();
            if(records == null)
            {
                //throw exception
            }
            return Ok(records);
        }

        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<WorkRecord>> GetById(int id)
        {
            var record = await workRecordRepository.GetByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<WorkRecord>> Create(AddWorkRecordInput newWorkRecordInput)
        {
            WorkRecord newWorkRecord;
            try
            {
                newWorkRecord = new WorkRecord
                {
                    Start = newWorkRecordInput.Start,
                    End = newWorkRecordInput.End,
                    Description = newWorkRecordInput.Description
                };
                await workRecordRepository.CreateAsync(newWorkRecord);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetById), new { id = newWorkRecord.Id }, newWorkRecord);
        }
    }
}
