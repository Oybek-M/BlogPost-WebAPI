using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Common.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.ImageUrl)
                .NotEmpty()
                .WithMessage("Rasmni tanlang");
                
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Title kiriting")
                .Length(3, 50)
                .WithMessage("Title: 3 va 50 belgi orasida bo'lsin");

            RuleFor(p => p.Content)
                .NotEmpty()
                .WithMessage("Content ni kiriting");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0)
                .WithMessage("Category tanlang, 0 bo'lmasin");

        }
    }
}