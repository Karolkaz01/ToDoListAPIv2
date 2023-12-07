using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private INoteService _noteService;
        private readonly ILogger<NoteController> _logger;

        public NoteController(INoteService noteService, ILogger<NoteController> logger)
        {
            _noteService = noteService;
            _logger = logger;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllNotes();
            if (notes == null) { return NotFound(); }

            return Ok(notes);
        }

        [HttpGet("/Test")]
        [EnableCors]
        public async Task<IActionResult> Test()
        {
            return Ok(DateTime.Now);
        }

        [HttpGet("{title}")]
        [EnableCors]
        public async Task<IActionResult> GetAllNotesByTitle(string title)
        {
            IEnumerable<Note> notes;
            if (string.IsNullOrEmpty(title))
                notes = await _noteService.GetAllNotes();
            else
                notes = await _noteService.GetAllNotesByTitle(title);

            if (notes == null) { return NotFound(); }

            return Ok(notes);
        }

        [HttpDelete]
        [EnableCors]
        public async Task<IActionResult> DeleteNote(int id)
        {
            await _noteService.DeleteNote(id);
            return Ok();
        }

        [HttpPut]
        [EnableCors]
        public async Task<IActionResult> PutNote(int id, string newNote)
        {
            var updatedNote = await _noteService.PutNote(id, newNote);
            if (updatedNote == null) { return NotFound(); }

            return Ok(updatedNote);
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> PostNote([FromBody] NoteDto note)
        {
            var notes = await _noteService.PostNote(note);
            if (notes == null) { return NotFound(); }

            return Ok(notes);
        }
    }
}
