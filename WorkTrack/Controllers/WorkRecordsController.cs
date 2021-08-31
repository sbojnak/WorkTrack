using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkTrack.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WorkRecordsController : ControllerBase
    {
        private readonly ILogger<WorkRecordsController> _logger;
        private readonly WorkTrackDbContext _workTrackDbContext;

        public WorkRecordsController(ILogger<WorkRecordsController> logger,
            WorkTrackDbContext dbContext)
        {
            _logger = logger;
            _workTrackDbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkRecord>>> Get()
        {
            var results = await _workTrackDbContext.WorkRecords.ToListAsync();
            return Ok(results);
        }

        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<WorkRecord>> GetById(int id)
        {
            var result = await _workTrackDbContext.WorkRecords.FindAsync(id);
            
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(WorkRecord newWorkRecord)
        {
            try
            {
                _workTrackDbContext.WorkRecords.Add(newWorkRecord);
                await _workTrackDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetById), new { id = newWorkRecord.Id }, newWorkRecord);
        }
    }
}
