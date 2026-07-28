using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteWebApi.Dtos;
using NoteWebApi.Services.Repositories;
using System.Security.Claims;

namespace NoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            var result = await _noteService.GetAllNotesAsync();

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultNoteDto>> GetNote(int id)
        {
            var result = await _noteService.GetNoteByIdAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Errors);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ResultNoteDto>> CreateNote(CreateNoteDto createNoteDto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized();
            }

            var result = await _noteService.CreateNoteAsync(createNoteDto, userId);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetNote), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResultNoteDto>> UpdateNote(int id, CreateNoteDto resultNote)
        {
            var result = await _noteService.UpdateNoteAsync(id, resultNote);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var result = await _noteService.DeleteNoteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }
    }
}
