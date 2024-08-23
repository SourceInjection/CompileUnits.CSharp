using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace CompileUnits.CSharp.Implementation
{
    internal static class TerminalSymbols
    {
        public static IReadOnlyList<TerminalSymbol> FromNode(ITree context)
        {
            var result = new List<TerminalSymbol>();
            for (int i = 0; i < context.ChildCount; i++)
            {
                var symbol = context.GetChild(i);
                if (symbol is ITerminalNode node)
                    result.Add(TerminalSymbol.FromToken(node.Symbol));
                else
                    result.AddRange(FromNode(symbol));
            }
            return result;
        }
    }
}
