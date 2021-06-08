using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            //RuleFor(c => c.PlaceId).NotEmpty();
            //RuleFor(c => c.CommentText).NotEmpty();
            //RuleFor(c => c.CommentText).MaximumLength(160);
        }
    }
}
