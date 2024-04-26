using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage("Ismni to'ldiring")
            .Length(3, 30)
            .WithMessage("Ism: 3 va 30 belgi orasida bo'lsin");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("Familyani to'ldiring")
            .Length(3, 30)
            .WithMessage("Familya: 3 va 30 belgi orasida bo'lsin");

        RuleFor(u => u.PhoneNumber)
            .NotEmpty()
            .WithMessage("Telefon raqamni kiriting")
            .Length(9, 13)
            .WithMessage("Telefon raqam: 9 va 13 belgi orasida bo'lsin");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Emailni to'ldiring")
            .Length(3, 50)
            .EmailAddress()
            .WithMessage("Email: 3 va 50 belgi orasida bo'lsin");

        RuleFor(u => u.Password)
            .NotEmpty()
            .WithMessage("Parolni kiriting")
            .Length(6, 16)
            .WithMessage("Parol 6 va 16 belgi orasida bo'lsin");
    }
}
