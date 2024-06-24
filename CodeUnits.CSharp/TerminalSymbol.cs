using Antlr4.Runtime;
using CodeUnits.CSharp.Common;

namespace CodeUnits.CSharp
{
    public class TerminalSymbol
    {
        internal TerminalSymbol(IToken token)
        {
            Kind = Symbol.KindFromAntlrType(token.Type);

            Text = token.Text;
            Line = token.Line;
            Column = token.Column;
            Index = token.TokenIndex;
        }

        public string Text { get; }

        public TerminalSymbolKind Kind { get; }

        public int Line { get; }

        public int Column { get; }

        public int Index { get; }

        public bool IsKind(TerminalSymbolKind kind) => Kind == kind;
    }
}
