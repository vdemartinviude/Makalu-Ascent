using MakaluTests.TestUtils;
using System.Reflection;
namespace MakaluTests;

public class MakaluGlobalTests
{
    [Fact]
    public void EnsureCanCreateMakaluLibrary()
    {
        MakaluTranslator makaluTranslator = new (MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly()));
        SourceAddressJson source = new SourceAddressJson();
        var destiby = makaluTranslator.Convert<DestinyaddressJson>(source);

    }

    [Fact]
    public void EnsureCanListConverts()
    {
        var converters = MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly());
        Assert.Contains(typeof(TestConverter), converters);
    }

    [Fact]
    public void EnsureCanDetermineTheGenericParametersOfAConverter()
    {
        var converters = MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly());
        var types = converters
            .Select(t => new {
                typeConvert = t,
                typeParameters = t.GetInterfaces().Single().GetGenericArguments()
            })
            .Where(t => t.typeParameters[0] == typeof(SourceAddressJson) && t.typeParameters[1] == typeof(DestinyaddressJson)).Single();

        Assert.Equal(typeof(TestConverter), types.typeConvert);
        
        
    }

    [Fact]
    public void AssureCanInvokeConvert()
    {
        var converters = MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly());
        var types = converters
            .Select(t => new {
                typeConvert = t,
                typeParameters = t.GetInterfaces().Single().GetGenericArguments()
            })
            .Where(t => t.typeParameters[0] == typeof(SourceAddressJson) && t.typeParameters[1] == typeof(DestinyaddressJson)).Single();



    }
}