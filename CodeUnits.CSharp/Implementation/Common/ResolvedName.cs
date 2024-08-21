using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Common
{
    internal static class ResolvedName
    {
        public static (string Name, TypeUsage AddressedInterface) FromContext(Namespace_or_type_nameContext context)
        {
            return FromContext(context.identifier(), context);
        }

        public static (string Name, TypeUsage AddressedInterface) FromContext(Method_member_nameContext context)
        {
            return FromContext(context.identifier(), context);
        }

        private static (string Name, TypeUsage AddressedInterface) FromContext(IdentifierContext[] identifierContext, ParserRuleContext context)
        {
            var nameChild = identifierContext[identifierContext.Length - 1];
            return (nameChild.GetText(), InterfaceFromChildren(context, nameChild));
        }

        private static TypeUsage InterfaceFromChildren(ParserRuleContext context, IParseTree excludedChild)
        {
            var symbols = new List<TerminalSymbol>();
            for (int i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);
                if (child != excludedChild)
                    symbols.AddRange(TerminalSymbols.FromNode(child));
            }

            return symbols.Count == 0
                ? null
                : TypeUsage.FromSymbols(symbols);
        }
    }
}
