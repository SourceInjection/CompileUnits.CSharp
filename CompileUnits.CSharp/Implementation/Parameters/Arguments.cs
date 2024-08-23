using System.Collections.Generic;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation.Parameters
{
    internal static class Arguments
    {
        public static IEnumerable<Argument> FromContext(Argument_listContext context)
        {
            if (context == null)
                yield break;

            foreach (var c in context.argument())
                yield return new Argument(Expression.FromContext(c.expression()), c.identifier()?.GetText());
        }

        public static IEnumerable<Argument> FromContext(Attribute_argumentContext[] context)
        {
            foreach (var c in context)
                yield return new Argument(Expression.FromContext(c.expression()), c.identifier()?.GetText());
        }
    }
}
