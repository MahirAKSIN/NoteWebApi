using FluentValidation;
using NoteWebApi.Dtos;

namespace NoteWebApi.Validators
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(q => q.UserName).
            Cascade(CascadeMode.Stop).
            NotEmpty().
            WithMessage("Kullanici adi bos olamaz").
            NotNull().
            WithMessage("3 karakterden az olamaz").
            MinimumLength(3);

            RuleFor(q => q.UserEmail).
            NotEmpty().
            WithMessage("Email adresi bos olamaz").
            EmailAddress(). 
            WithMessage("Email adres olmalı");


            RuleFor(q => q.Password).
            NotEmpty().
            WithMessage("Parola bos olamaz").
            MinimumLength(6).
            WithMessage("Parola en az 6 karakter olmalı");
        }
    }
}
