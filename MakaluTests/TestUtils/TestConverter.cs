using FluentValidation;
using MakaluLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluTests.TestUtils;

public class TestConverter : IJsonConversionStrategy<SourceAddressJson, DestinyaddressJson>
{
    public AbstractValidator<ISourceJson> SourceValidator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    AbstractValidator<ISourceJson> IJsonConversionStrategy<SourceAddressJson, DestinyaddressJson>.SourceValidator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    DestinyaddressJson IJsonConversionStrategy<SourceAddressJson, DestinyaddressJson>.InternalConvert(ISourceJson sourceJson)
    {
        throw new NotImplementedException();
    }
}
