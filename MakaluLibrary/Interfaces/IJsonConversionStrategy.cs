using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaluLibrary.Interfaces;

public interface IJsonConversionStrategy<TSource,TDestiny> where TSource : ISourceJson where TDestiny : IDestinyJson
{
    public AbstractValidator<ISourceJson> SourceValidator { get; set; }
    public abstract TDestiny InternalConvert(ISourceJson sourceJson);
}

public static class JsonConversionStrategyExtensions
{
    public static IDestinyJson Convert(this IJsonConversionStrategy<ISourceJson,IDestinyJson> strategy,ISourceJson sourceJson)
    {
        var result = strategy.SourceValidator.Validate(sourceJson);

        if (!result.IsValid)
        {
            throw new Exception("Source error!");
        }
        return strategy.InternalConvert(sourceJson);
    }
}