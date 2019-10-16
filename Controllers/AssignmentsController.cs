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
    public class AssignmentsController : ControllerBase
    {
        private DatabaseContext context;

        public AssignmentsController(DatabaseContext _context)
        {
            this.context = _context;
        }

        [HttpPost]
        public async Task<ActionResult<Assign>> CreateEntry([FromBody]Assign assignment)
        {
            await context.Assignments.AddAsync(assignment);
            await context.SaveChangesAsync();
            return assignment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assign>>> GetAllAssignments()
        {
            var assignments = context.Assignments.OrderByDescending(assignment => assignment.DateTime);
            return await assignments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneAssignment(int id)
        {
            var assignment = await context.Assignments.FirstOrDefaultAsync(a => a.Id == id);
            {
                if (assignment == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(assignment);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAssignment(int id)
        {
            var assignment = context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }
            else
            {
                context.Assignments.Remove(assignment);
                context.SaveChanges();
                return Ok(new DeleteAssignmentResponse { Assign = assignment });
            }
        }
    }
}