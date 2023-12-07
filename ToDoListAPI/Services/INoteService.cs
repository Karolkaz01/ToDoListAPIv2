using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface INoteService
    {
        Task DeleteNote(int id);
        Task<IEnumerable<NoteDto>> GetAllNotes();
        Task<NoteDto> PostNote(string note);
        Task<NoteDto> PutNote(int id, string newNote);
    }
}