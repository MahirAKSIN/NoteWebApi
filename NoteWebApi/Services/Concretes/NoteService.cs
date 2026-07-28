using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NoteWebApi.Common;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;
using NoteWebApi.Repository.Interfaces;
using NoteWebApi.Services.Repositories;

namespace NoteWebApi.Services.Concretes
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateNoteDto> _validator;

        public NoteService(INoteRepository repository, IMapper mapper, IValidator<CreateNoteDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResult<ResultNoteDto>> CreateNoteAsync(CreateNoteDto dto, int userId)
        {
            ValidationResult validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return ServiceResult<ResultNoteDto>.Fail(errorMessage);
            }
            var note = _mapper.Map<Note>(dto);
            note.UserId = userId;
            note.CreatedAt = DateTime.Now;
            await _repository.AddAsync(note);

            var resultDto = _mapper.Map<ResultNoteDto>(note);

            return ServiceResult<ResultNoteDto>.Ok(resultDto);
        }

        public async Task<ServiceResult<bool>> DeleteNoteAsync(int id)
        {
            var existingNote = await _repository.GetByIdAsync(id);
            if (existingNote == null)
            {
                return ServiceResult<bool>.Fail(new List<string> { "Not bulunamadı" });
            }
            await _repository.DeleteByIdAsync(existingNote);


            return ServiceResult<bool>.Ok(true);
        }

        public async Task<ServiceResult<ResultNoteDto>> GetNoteByIdAsync(int id)
        {
            var note = await _repository.GetByIdAsync(id);
            if (note == null)
            {
                return ServiceResult<ResultNoteDto>.Fail(new List<string> { "Not Bulunamadı" });
            }
            var noteDto = _mapper.Map<ResultNoteDto>(note);
            return ServiceResult<ResultNoteDto>.Ok(noteDto);

        }

        public async Task<ServiceResult<List<ResultNoteDto>>> GetAllNotesAsync()
        {
            var notes = await _repository.GetAllAsync();
            var notesDto = _mapper.Map<List<ResultNoteDto>>(notes);
            return ServiceResult<List<ResultNoteDto>>.Ok(notesDto);
        }

        public async Task<ServiceResult<ResultNoteDto>> UpdateNoteAsync(int id, CreateNoteDto dto)
        {
            ValidationResult validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return ServiceResult<ResultNoteDto>.Fail(errorMessage);

            }

            var existingNote = await _repository.GetByIdAsync(id);

            if (existingNote == null)
            {
                return ServiceResult<ResultNoteDto>.Fail(new List<string> { "Not bulunamadı" });
            }
            await _repository.UpdateAsync(existingNote);
            var resultDto = _mapper.Map<ResultNoteDto>(existingNote);

            return ServiceResult<ResultNoteDto>.Ok(resultDto);

        }

    }
}
