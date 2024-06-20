using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class ExternAliases
    {
        public static List<ExternAliasDefinition> FromContext(Extern_alias_directivesContext context)
        {
            return context.extern_alias_directive()
                .Select(c => new ExternAliasDefinition(c.identifier().GetText())).ToList();
        }
    }
}
