using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone_api.Models;
using capstone_api.ViewModels;
using capstone_backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace capstone_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientLogsController : ControllerBase
    {
        private DatabaseContext context;

        public PatientLogsController(DatabaseContext _context)
        {
            this.context = _context;
        }

        [HttpPost]
        public async Task<ActionResult<PatientLog>> CreateEntry([FromBody]PatientLog log)
        {
            await context.PatientLogs.AddAsync(log);
            await context.SaveChangesAsync();
            return log;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientLog>>> GetAllPatientLogs()
        {
            var logs = context.PatientLogs.OrderByDescending(log => log.DateTime);
            return await logs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOnePatientLog(int id)
        {
            var log = await context.PatientLogs.FirstOrDefaultAsync(l => l.Id == id);
            if (log == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(log);
            }
        }

        [HttpDelete]
        public ActionResult DeleteLog(int id)
        {
            var log = context.PatientLogs.FirstOrDefault(l => l.Id == id);
            if (log == null)
            {
                return NotFound();
            }
            else
            {
                context.PatientLogs.Remove(log);
                context.SaveChanges();
                return Ok(new DeletePatientLogResponse { PatientLog = log });
            }
        }
    }
}