using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Common
{
    internal class ImplementedInterfaces
    {
        public static IEnumerable<TypeUsage> FromContext(Interface_type_listContext context)
        {
            if (context == null)
                yield break;

            foreach (var c in context.namespace_or_type_name())
                yield return new TypeUsage(c);
        }
    }
}
