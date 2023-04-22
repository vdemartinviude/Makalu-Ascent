using MakaluLibrary.Classes;
using MakaluLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MakaluLibrary;

public static class MakaluTranslatorHelpers
{
    public static IEnumerable<ConvertDefinition> GetJsonConversionStrategies(Assembly assembly)
    {
        var genericClass = typeof(BaseConverter<,>);
        return assembly.GetTypes()
            .Where(t => t.IsClass &&
                        !t.IsAbstract &&
                        t.BaseType != null &&
                        t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == genericClass)
            .Select(t => new ConvertDefinition
            {
                Converter = t,
                JsonInput = t.BaseType!.GetGenericArguments()[0],
                JsonOutput = t.BaseType!.GetGenericArguments()[1]
            });
            
    }

}

public class ConvertDefinition
{
    public Type Converter { get; set; }
    public Type JsonInput { get; set; } 
    public Type JsonOutput { get; set; }
}
