using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    internal static class ExternAliasDefinitions
    {
        public static List<ExternAliasDefinition> FromContext(Extern_alias_directivesContext context)
        {
            if (context == null)
                return new List<ExternAliasDefinition>();

            return context.extern_alias_directive()
                .Select(c => new ExternAliasDefinition(c.identifier().GetText())).ToList();
        }
    }
}
