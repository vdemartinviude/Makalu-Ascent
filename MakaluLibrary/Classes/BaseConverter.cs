using FluentValidation;
using MakaluLibrary.Exception;
using MakaluLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluLibrary.Classes;

public abstract class BaseConverter<TSource,TDestiny> where TSource : ISourceJson where TDestiny : IDestinyJson
{ 

    public abstract AbstractValidator<TSource> SourceValidator { get; }

    public abstract IDestinyJson InternalConvert(TSource sourceJson);


    public IDestinyJson Convert(TSource sourceJson)
    {
        var validate = SourceValidator.Validate(sourceJson);

        if (!validate.IsValid)
        {
            var error = validate.Errors.FirstOrDefault();
            throw new InvalidDocumentException(error.ErrorMessage, error.PropertyName);
        }
        return InternalConvert(sourceJson);
    }

}
