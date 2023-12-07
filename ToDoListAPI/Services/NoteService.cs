using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Controllers;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class NoteService : INoteService
    {
        private ToDoListDBContext _dbContext;
        private readonly ILogger<NoteController> _logger;

        public NoteService(ToDoListDBContext dbContext, ILogger<NoteController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetAllNotesByTitle(string title)
        {
            var allNotes = await _dbContext.Notes.ToListAsync();
            return allNotes.Where(n => n.Title.Contains(title));
        }

        public async Task DeleteNote(int id)
        {
            var entity = await GetNote(id);

            _dbContext.Notes.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<Note> PutNote(int id, string newNote)
        {
            var entity = await GetNote(id);

            entity.NoteValue = newNote;
            _dbContext.Notes.Update(entity);
            _dbContext.SaveChanges();
            return await GetNote(id);
        }

        public async Task<Note> PostNote(NoteDto note)
        {
            var response = await _dbContext.Notes.AddAsync(new Note() { NoteValue = note.NoteValue, Title = note.Title });
            _dbContext.SaveChanges();
            return await GetNote(response.Entity.Id);
        }

        public async Task<Note> GetNote(int id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
                throw new Exception("Entity Not Found!");

            return note;
        }


    }
}
