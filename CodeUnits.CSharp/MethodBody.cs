using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp
{
    public sealed class MethodBody
    {
        internal MethodBody(BodyContext context)
        {
            Symbols = Common.Symbols.FromNode(context);
        }

        public IReadOnlyList<TerminalSymbol> Symbols { get; }
    }
}
