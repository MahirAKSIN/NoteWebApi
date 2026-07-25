using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteWebApi.Datas;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;
using NoteWebApi.Services.Repositories;

namespace NoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var result = await _noteService.CreateNoteAsync(createNoteDto);

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
        [HttpDelete]
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
