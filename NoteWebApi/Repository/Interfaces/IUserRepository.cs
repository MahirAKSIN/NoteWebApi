using NoteWebApi.Entities;

namespace NoteWebApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User> GetUserNameAsync(string username);
        Task AddAsync(User user);
        Task<bool> ExistsByUsernameAsync(string username);

    }
}
