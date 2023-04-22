using MakaluLibrary.Classes;
using MakaluLibrary.Exception;
using MakaluLibrary.Interfaces;
using System.Reflection;

namespace MakaluLibrary;

public class MakaluTranslator
{
    private readonly IEnumerable<ConvertDefinition> _converters;
    public MakaluTranslator(IEnumerable<ConvertDefinition> jsonConversionStrategies)
    {
        _converters = jsonConversionStrategies;
    }

    public TDestiny Convert<TDestiny>(ISourceJson sourceJson)
    {
        var converterType = _converters
                                .Where(cn => cn.JsonInput == sourceJson.GetType() && cn.JsonOutput == typeof(TDestiny))
                                .Select(cn => cn.Converter).SingleOrDefault() 
                                ?? throw new System.Exception("Converter not found!");
        var ActualConverter = Activator.CreateInstance(converterType)!;
        try
        {
            TDestiny result = (TDestiny)converterType.GetMethod("Convert")!.Invoke(ActualConverter, new object[] { sourceJson })!;
            return result;
        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException!;
        }

    }

}