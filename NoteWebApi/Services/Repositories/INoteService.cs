using NoteWebApi.Common;
using NoteWebApi.Dtos;

namespace NoteWebApi.Services.Repositories
{
    public interface INoteService
    {
        Task<ServiceResult<List<ResultNoteDto>>> GetAllNotesAsync();
        Task<ServiceResult<ResultNoteDto>> GetNoteByIdAsync(int id,int userId);
        Task<ServiceResult<ResultNoteDto>> CreateNoteAsync(CreateNoteDto dto, int userId);
        Task<ServiceResult<ResultNoteDto>> UpdateNoteAsync(int id, CreateNoteDto dto,int userId);
        Task<ServiceResult<bool>> DeleteNoteAsync(int id, int userId);

    }
}
