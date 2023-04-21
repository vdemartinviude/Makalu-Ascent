using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluTests.TestUtils;

internal class SourceValidator : AbstractValidator<SourceAddressJson>
{
    public SourceValidator()
    {
        RuleFor(x => x.Street).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.PostalCode).Matches(@"\d{5}-\d{3}");
        RuleFor(x => x.Country).NotEmpty();
    }
}
