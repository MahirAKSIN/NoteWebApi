using Microsoft.EntityFrameworkCore;
using NoteWebApi.Datas;
using NoteWebApi.Entities;
using NoteWebApi.Repository.Interfaces;

namespace NoteWebApi.Repository.Concretes
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            return await _appDbContext.Users.AnyAsync(q => q.UserName == username);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _appDbContext.Users.Include(q => q.Notes).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _appDbContext.Users.Include(q => q.Notes).FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<User> GetUserNameAsync(string username)
        {
            return await _appDbContext.Users.Include(q => q.Notes).FirstOrDefaultAsync(a => a.UserName == username);
        }
    }
}
