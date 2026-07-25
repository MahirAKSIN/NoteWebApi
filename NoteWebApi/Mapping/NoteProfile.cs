using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;

namespace NoteWebApi.Mapping
{
    public class NoteProfile : Profile
    {

        public NoteProfile()
        {
            CreateMap<CreateNoteDto, Note>();
            CreateMap<Note, ResultNoteDto>();
        }

    }
}
