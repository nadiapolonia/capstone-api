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
    public class PatientsController : ControllerBase
    {
        private DatabaseContext context;

        public PatientsController(DatabaseContext _context)
        {
            this.context = _context;
        }
        [HttpPost]
        public async Task<ActionResult<Patient>> CreateEntry([FromBody]Patient patient)
        {
            await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
            return patient;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = context.Patients.OrderBy(patient => patient.LastName);
            return await patients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOnePatient(int id)
        {
            var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patient);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Patient> UpdatePatient(int id, [FromBody]Patient newInfo)
        {
            if (id != newInfo.Id)
            {
                return BadRequest();
            }

            context.Entry(newInfo).State = EntityState.Modified;
            context.SaveChanges();
            return newInfo;
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
                return Ok(new DeletePatientResponse { Patient = patient });
            }
        }

        //Notes Post/Get

        [HttpPost("{patientId}/notes")]
        public ActionResult<Notes> CreateNote(int patientId, [FromBody]Notes notes)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                notes.PatientId = patientId;
                context.Note.Add(notes);
                context.SaveChanges();
                return Ok(new
                {

                });
            }

        }

        [HttpGet("{patientId}/notes")]
        public async Task<ActionResult<IEnumerable<Notes>>> GetNotes(int patientId)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {

                var notes = context.Note.Where(w => w.PatientId == patientId).OrderByDescending(note => note.DateTime);
                return await notes.ToListAsync();
            }
        }

        [HttpGet("{patientId}/notes/{id}")]

        public async Task<ActionResult> GetOneNote(int id)
        {
            var note = await context.Note.FirstOrDefaultAsync(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(note);
            }
        }

        [HttpDelete("{patientId}/notes/{id}")]
        public ActionResult DeleteNote(int id)
        {
            var note = context.Note.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                context.Note.Remove(note);
                context.SaveChanges();
                return Ok(new DeleteNoteResponse { Notes = note });
            }
        }

        //AssignHW

        [HttpPost("{patientId}/assign")]
        public ActionResult<Notes> CreateAssignment(int patientId, [FromBody]Assign assign)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                assign.PatientId = patientId;
                context.Assignments.Add(assign);
                context.SaveChanges();
                return Ok(new
                {

                });
            }

        }

        [HttpGet("{patientId}/assign")]
        public async Task<ActionResult<IEnumerable<Assign>>> GetAssignnents(int patientId)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {

                var assign = context.Assignments.Where(w => w.PatientId == patientId).OrderByDescending(a => a.DateTime);
                return await assign.ToListAsync();
            }
        }

        [HttpGet("{patientId}/assign/{id}")]

        public async Task<ActionResult> GetOneAssignment(int id)
        {
            var assign = await context.Assignments.FirstOrDefaultAsync(a => a.Id == id);
            if (assign == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(assign);
            }
        }

        [HttpDelete("{patientId}/assign/{id}")]
        public ActionResult DeleteAssignment(int id)
        {
            var assign = context.Assignments.FirstOrDefault(a => a.Id == id);
            if (assign == null)
            {
                return NotFound();
            }
            else
            {
                context.Assignments.Remove(assign);
                context.SaveChanges();
                return Ok(new DeleteAssignmentResponse { Assign = assign });
            }
        }
    }
}