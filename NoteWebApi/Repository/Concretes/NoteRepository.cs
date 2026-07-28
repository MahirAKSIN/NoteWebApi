using Microsoft.EntityFrameworkCore;
using NoteWebApi.Datas;
using NoteWebApi.Entities;
using NoteWebApi.Repository.Interfaces;

namespace NoteWebApi.Repository.Concretes
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _appDbContext;

        public NoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Note note)
        {
            _appDbContext.Notes.Add(note);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Note note)
        {
            var note_ = _appDbContext.Notes.Remove(note);

            if (note_ != null)

                await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _appDbContext.Notes.AnyAsync(q => q.Id == id);
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return _appDbContext.Notes.ToList();
        }

        public async Task<Note> GetByIdAsync(int id)
        {

            var note = await _appDbContext.Notes.FindAsync(id);


            return note;
        }

        public async Task UpdateAsync(Note note)
        {
            _appDbContext.Notes.Update(note);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
