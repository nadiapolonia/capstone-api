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
    public class PatientEmergencyLogsController : ControllerBase
    {
        private DatabaseContext context;

        public PatientEmergencyLogsController(DatabaseContext _context)
        {
            this.context = _context;
        }

        [HttpPost]
        public async Task<ActionResult<PatientEmergencyLog>> CreateEntry([FromBody]PatientEmergencyLog log)
        {
            await context.PatientEmergencyLogs.AddAsync(log);
            await context.SaveChangesAsync();
            return log;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientEmergencyLog>>> GetAllEmergencyPatientLogs()
        {
            var logs = context.PatientEmergencyLogs.OrderByDescending(log => log.DateTime);
            return await logs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOnePatientLog(int id)
        {
            var log = await context.PatientEmergencyLogs.FirstOrDefaultAsync(l => l.Id == id);
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
            var log = context.PatientEmergencyLogs.FirstOrDefault(l => l.Id == id);
            if (log == null)
            {
                return NotFound();
            }
            else
            {
                context.PatientEmergencyLogs.Remove(log);
                context.SaveChanges();
                return Ok(new DeletePatientEmergencyLogResponse { PatientEmergencyLog = log });
            }
        }
    }
}