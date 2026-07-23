using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteWebApi.Datas;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;

namespace NoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public NotesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultNoteDto>>> GetNotes()
        {
            var notes = await _appDbContext.Notes.ToListAsync();

            var notesDto = notes.Select(x => new ResultNoteDto
            {

                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            }).ToList();

            return notesDto;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ResultNoteDto>> GetNote(int id)
        {
            var note = await _appDbContext.Notes.FindAsync(id);

            if (note == null) return NotFound();

            var dtoNote = new ResultNoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            return dtoNote;
        }
        [HttpPost]

        public async Task<ActionResult<ResultNoteDto>> CreateNote(CreateNoteDto createNoteDto) {

            var note = new Note
            {
                Title = createNoteDto.Title,
                Content = createNoteDto.Content,
            };
        
            _appDbContext.Notes.Add(note);
            await _appDbContext.SaveChangesAsync();

            var resultNoteDto = new ResultNoteDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return CreatedAtAction(nameof(GetNote) ,new {id=note.Id},resultNoteDto);
        }

    }
}
