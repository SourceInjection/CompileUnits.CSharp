using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp
{
    public sealed class Code
    {
        internal Code(BlockContext context)
        {
            Symbols = Common.Symbols.FromNode(context);
        }

        internal Code(IReadOnlyList<TerminalSymbol> symbols)
        {
            Symbols = symbols;
        }

        public IReadOnlyList<TerminalSymbol> Symbols { get; }
    }
}
