using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface INoteService
    {
        Task DeleteNote(int id);
        Task<IEnumerable<Note>> GetAllNotes();
        Task<IEnumerable<Note>> GetAllNotesByTitle(string title);
        Task<Note> PostNote(NoteDto note);
        Task<Note> PutNote(int id, string newNote);
    }
}