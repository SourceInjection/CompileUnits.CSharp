using Antlr4.Runtime;
using CodeUnits.CSharp.Implementation.Common;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp.Implementation
{
    internal class TerminalSymbol : ITerminalSymbol
    {
        internal TerminalSymbol(TerminalSymbolKind kind, string value)
        {
            Kind = kind;
            Value = value;
        }

        public ITreeNode ParentNode { get; internal set; }

        public string Value { get; }

        public TerminalSymbolKind Kind { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Enumerable.Empty<ITreeNode>();

        public override string ToString()
        {
            return Value;
        }

        public static TerminalSymbol FromToken(IToken token)
        {
            return new TerminalSymbol(Symbol.KindFromAntlrType(token.Type), token.Text);
        }
    }
}
