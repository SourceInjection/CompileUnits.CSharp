using Antlr4.Runtime;
using CodeUnits.CSharp.Common;

namespace CodeUnits.CSharp
{
    public sealed class TerminalSymbol
    {
        internal TerminalSymbol(TerminalSymbolKind kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        internal TerminalSymbol(IToken token)
            : this(Symbol.KindFromAntlrType(token.Type), token.Text)
        { }

        public string Value { get; }

        public TerminalSymbolKind Kind { get; }

        public bool IsKind(TerminalSymbolKind kind) => Kind == kind;

        public override string ToString()
        {
            return Value;
        }
    }
}
