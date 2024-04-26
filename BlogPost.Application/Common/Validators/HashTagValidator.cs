using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Common.Validators
{
    public class HashTagValidator : AbstractValidator<HashTag>
    {
        public HashTagValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty()
                .WithMessage("Tag nomini kiriting")
                .Length(2, 12)
                .WithMessage("Tag nomi: 2 va 12 belgi orasida bo'lsin");
        }
    }
}