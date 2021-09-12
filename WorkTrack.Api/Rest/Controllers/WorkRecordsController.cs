using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTrack.Core.CommandModels;
using WorkTrack.Core.Entities;
using WorkTrack.Core.QueryModels;

namespace WorkTrack.Api.Rest.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkRecordsController : ControllerBase
    {
        private readonly ILogger<WorkRecordsController> logger;
        private readonly IMediator mediator;

        public WorkRecordsController(ILogger<WorkRecordsController> logger,
            IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkRecord>>> GetAsync([FromQuery] GetWorkRecordsQueryModel filter)
        {
            var records = await mediator.Send(filter);
            if (records == null)
            {
                //throw exception
            }
            return Ok(records);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<WorkRecord>> GetByIdAsync(int id)
        {
            var filter = new GetWorkRecordsQueryModel(Id: id, Start: null, End: null, Description: null);

            var record = (await mediator.Send(filter)).SingleOrDefault();
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<WorkRecord>> CreateAsync(CreateWorkRecordCommandModel newWorkRecordInput)
        {
            WorkRecord newWorkRecord;
            try
            {
                newWorkRecord = await mediator.Send(newWorkRecordInput);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newWorkRecord.Id }, newWorkRecord);
        }
    }
}
