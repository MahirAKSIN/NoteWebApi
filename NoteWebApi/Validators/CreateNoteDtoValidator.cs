using FluentValidation;
using NoteWebApi.Dtos;

namespace NoteWebApi.Validators
{
    public class CreateNoteDtoValidator : AbstractValidator<CreateNoteDto>
    {
        public CreateNoteDtoValidator()
        {
            RuleFor(q => q.Title).
            Cascade(CascadeMode.Stop).
            NotEmpty().
            WithMessage("Baslik bos olamaz").
            NotNull().
            WithMessage("4 karakterden az olamaz").
            MinimumLength(4).
            MaximumLength(100).
            WithMessage("100 karakterden fazla olamaz");

            RuleFor(q => q.Content).
            NotEmpty().
            WithMessage("Icerik bos olamaz").
            MaximumLength(1000).
            WithMessage("1000 karakterden fazla olamaz");
        }
    }
}
