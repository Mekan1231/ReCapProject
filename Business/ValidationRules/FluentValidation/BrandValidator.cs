using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(2);
            RuleFor(p => p.Name).Must(StartWithB).WithMessage("B harfi ile başlaması gerekiyor");

            
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
