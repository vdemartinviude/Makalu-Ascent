using MakaluLibrary.Interfaces;

namespace MakaluLibrary;

public class MakaluTranslator
{
    private readonly IEnumerable<Type> _converters;
    public MakaluTranslator(IEnumerable<Type> jsonConversionStrategies)
    {
        _converters = jsonConversionStrategies;
    }
    public T Convert<T>(ISourceJson sourceJson)
    {
        var convertType = _converters
            .Where(t => sourceJson.GetType().IsAssignableFrom(t.GetGenericArguments()[0]))
            .Where(t => typeof(T).IsAssignableFrom(t.GetGenericArguments()[1])) 
            .SingleOrDefault(); 

        var convert = (IJsonConversionStrategy<ISourceJson,IDestinyJson>) Activator.CreateInstance(convertType);

        return (T) convert.Convert(sourceJson);

    }
}