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
    public static IEnumerable<Type> GetJsonConversionStrategies(Assembly assembly)
    {
        var genericInterface = typeof(IJsonConversionStrategy<,>);
        return assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericInterface))
            .ToList();
    }

}
