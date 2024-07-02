using Antlr4.Runtime;
using CodeUnits.CSharp.Implementation.Common;

namespace CodeUnits.CSharp.Implementation
{
    public sealed class TerminalSymbol : ITerminalSymbol
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

        public override string ToString()
        {
            return Value;
        }
    }
}
