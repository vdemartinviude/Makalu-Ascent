using MakaluLibrary.Exception;
using MakaluLibrary.Interfaces;
using MakaluTests.TestUtils;
using System.Reflection;
using Xunit.Abstractions;

namespace MakaluTests;

public class MakaluGlobalTests
{
    private readonly ITestOutputHelper _outputHelper;

    public MakaluGlobalTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void ListConvertTests()
    {
        var converts = MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly())!.ToList();
        Assert.Single(converts);
        Assert.Equal(typeof(SourceAddressJson),converts.Single().JsonInput);  
        Assert.Equal(typeof(DestinyAddressJson),converts.Single().JsonOutput);
        Assert.Equal(typeof(TestConverter), converts.Single().Converter);
    }
    
    [Fact]
    public void InvokeConvertTest()
    {
        var sourceJson = new SourceAddressJson()
        {
            Street = "Rua José Zappi, 988",
            Country = "Brazil",
            PostalCode = "03128141"
        };
        MakaluTranslator makaluTranslator = new(MakaluTranslatorHelpers.GetJsonConversionStrategies(Assembly.GetExecutingAssembly()));
        Assert.Throws<InvalidDocumentException>(()=> makaluTranslator.Convert<DestinyAddressJson>(sourceJson));
    }
}