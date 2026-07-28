using NoteWebApi.Common;
using NoteWebApi.Dtos;

namespace NoteWebApi.Repository.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> LoginAsync(LoginDto dto);
    }
}
