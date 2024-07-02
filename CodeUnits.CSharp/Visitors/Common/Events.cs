using CodeUnits.CSharp.Visitors.ValueTypes;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal class Events
    {
        public static IEnumerable<EventDefinition> FromContext(Event_declarationContext context, CommonDefinitionInfo commonInfo)
        {
            if (context == null)
                yield break;
        }
    }
}
