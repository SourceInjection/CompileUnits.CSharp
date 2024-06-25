using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace CodeUnits.CSharp.Common
{
    internal class Symbols
    {
        public static IReadOnlyList<TerminalSymbol> FromNode(ITree context)
        {
            var result = new List<TerminalSymbol>();
            for (int i = 0; i < context.ChildCount; i++)
            {
                var symbol = context.GetChild(i);
                if (symbol is ITerminalNode node)
                    result.Add(new TerminalSymbol(node.Symbol));
                else
                    result.AddRange(FromNode(symbol));
            }
            return result;
        }
    }
}
