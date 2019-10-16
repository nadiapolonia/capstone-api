using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstone_api.Models;
using capstone_api.ViewModels;
using capstone_backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// namespace dotnet_sdg_template.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class NoteController : ControllerBase
//     {
//         private readonly DatabaseContext _context;

//         public NoteController(DatabaseContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Notes>>> GetAllNotes()
//         {
//             _context = new DatabaseContext();
//             return await _context.Note.ToListAsync();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<Notes>> GetNote(int id)
//         {
//             var note = await _context.Note.FindAsync(id);

//             if (note == null)
//             {
//                 return NotFound();
//             }
//             return note;
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateNote(int id, Notes notes)
//         {
//             if (id != notes.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(notes).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!NotesExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return NoContent();
//         }

//         [HttpPost]
//         public async Task<ActionResult<Notes>> PostNote(Notes notes)
//         {
//             _context.Note.Add(notes);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetNote", new { id = notes.Id }, notes);
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult<Notes>> DeleteNote(int id)
//         {
//             var note = await _context.Note.FindAsync(id);
//             if (note == null)
//             {
//                 return NotFound();
//             }

//             _context.Note.Remove(note);
//             await _context.SaveChangesAsync();
//             return note;
//         }

//         private bool NotesExists(int id)
//         {
//             return _context.Note.Any(e => e.Id == id);
//         }



//Method One

// [HttpPost]
// public async Task<ActionResult<Notes>> PostNote(Notes note)
// {
//     await context.Note.AddAsync(note);
//     await context.SaveChangesAsync();
//     return note;
// }

// [HttpGet]
// public async Task<ActionResult<IEnumerable<Notes>>> GetAllNotes()
// {
//     var notes = context.Note.OrderByDescending(note => note.DateTime);
//     return await notes.ToListAsync();
// }

// [HttpGet("{id}")]
// public async Task<ActionResult> GetOneNote(int id)
// {
//     var note = await context.Note.FirstOrDefaultAsync(n => n.Id == id);
//     if (note == null)
//     {
//         return NotFound();
//     }
//     else
//     {
//         return Ok(note);
//     }
// }

// [HttpDelete]
// public ActionResult DeleteNote(int id)
// {
//     var note = context.Note.FirstOrDefault(n => n.Id == id);
//     if (note == null)
//     {
//         return NotFound();
//     }
//     else
//     {
//         context.Note.Remove(note);
//         context.SaveChanges();
//         return Ok(new DeleteNoteResponse { Notes = note });
//     }
// }
//     }
// }