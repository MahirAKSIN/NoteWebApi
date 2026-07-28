

using NoteWebApi.Common;
using NoteWebApi.Dtos;

namespace NoteWebApi.Services.Repositories
{
    public interface IUserService
    {
        Task<ServiceResult<ResultUserDto>> CreateUserAsync(CreateUserDto dto);
        Task<ServiceResult<List<ResultUserDto>>> GetAllUserAsync();
        Task<ServiceResult<ResultUserDto>> GetByIdUserAsync(int id);
    }
}
