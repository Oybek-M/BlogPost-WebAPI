using BlogPost.Domain.Entities;
using FluentValidation;

namespace BlogPost.Application.Common.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.CommentText)
                .NotEmpty()
                .WithMessage("Comment bo'sh bo'lmasin")
                .MinimumLength(1)
                .WithMessage("Kamida 1ta belgi bo'lsin");
        }
    }
}