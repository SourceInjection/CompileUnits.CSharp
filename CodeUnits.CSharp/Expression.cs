using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp
{
    public sealed class Expression
    {
        internal Expression(ExpressionContext context)
        {
            Symbols = Common.Symbols.FromNode(context);
        }

        public IReadOnlyList<TerminalSymbol> Symbols { get; }
    }
}
