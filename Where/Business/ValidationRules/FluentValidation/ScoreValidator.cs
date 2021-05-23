using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ScoreValidator : AbstractValidator<Score>
    {
        public ScoreValidator()
        {
            RuleFor(s => s.PlaceId).NotEmpty();
            RuleFor(s => s.ServiceScore).NotEmpty();
            RuleFor(s => s.CovidScore).NotEmpty();
            RuleFor(s => s.ServiceScore).GreaterThanOrEqualTo(0);
            RuleFor(s => s.ServiceScore).LessThanOrEqualTo(5);
            RuleFor(s => s.CovidScore).GreaterThanOrEqualTo(0);
            RuleFor(s => s.CovidScore).LessThanOrEqualTo(5);
        }
    }
}
