using NoteWebApi.Entities;

namespace NoteWebApi.Repository.Interface
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note> GetByIdAsync(int id);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteByIdAsync(Note note);
        Task<bool> ExistsAsync(int id);
    }
}
