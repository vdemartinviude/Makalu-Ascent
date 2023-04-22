using FluentValidation;
using MakaluLibrary.Classes;
using MakaluLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluTests.TestUtils;

public class TestConverter : BaseConverter<SourceAddressJson,DestinyAddressJson> 
{
    public override AbstractValidator<SourceAddressJson> SourceValidator { get { return new TesteSourceValidator(); }  }

    public override IDestinyJson InternalConvert(SourceAddressJson sourceJson)
    {
        SourceAddressJson source = (SourceAddressJson)sourceJson;
        return new DestinyAddressJson
        {
            FullAddress = String.Concat(source.Street, " ", source.City, " ", source.Country, " ", source.PostalCode)
        };
    }
}
