using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Common.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category nomini kiriting")
                .Length(2, 20)
                .WithMessage("Category nomi: 2 va 20 belgi orasida bo'lsin");
        }
    }
}