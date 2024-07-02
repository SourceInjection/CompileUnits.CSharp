using System.Collections.Generic;
using CodeUnits.CSharp.Visitors;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Usings
{
    internal static class UsingDirectives
    {
        public static List<UsingDirectiveDefinition> FromContext(Using_directivesContext context)
        {
            if (context == null)
                return new List<UsingDirectiveDefinition>();

            var usingDirectives = new List<UsingDirectiveDefinition>();
            var visitor = new UsingVisitor();
            foreach (var c in context.using_directive())
            {
                var directive = visitor.VisitUsing_directive(c);
                if (directive != null)
                    usingDirectives.Add(directive);
            }
            return usingDirectives;
        }
    }
}
