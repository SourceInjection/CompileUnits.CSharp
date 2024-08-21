using Antlr4.Runtime;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    internal class CodeFragment : ICodeFragment
    {
        private CodeFragment(IReadOnlyList<TerminalSymbol> symbols)
        {
            Symbols = symbols;
            foreach (var symbol in symbols)
                symbol.ParentNode = this;
        }

        public ITreeNode ParentNode { get; internal set; }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public IEnumerable<ITreeNode> ChildNodes() => Symbols;

        public static CodeFragment FromContext(Throwable_expressionContext context)
        {
            if (context == null)
                return null;

            var tokens = TerminalSymbols.FromNode(context)
                .Prepend(new TerminalSymbol(TerminalSymbolKind.RightArrow, "=>"))
                .Append(new TerminalSymbol(TerminalSymbolKind.Semicolon, ";"))
                .ToArray();

            return new CodeFragment(tokens);
        }

        public static CodeFragment FromContext(ExpressionContext context)
        {
            return FromAnyContext(context);
        }

        public static CodeFragment FromContext(BodyContext context)
        {
            return FromAnyContext(context);
        }

        public static CodeFragment FromContext(BlockContext context)
        {
            return FromAnyContext(context);
        }

        public static CodeFragment FromContext(Array_initializerContext context)
        {
            return FromAnyContext(context);
        }

        private static CodeFragment FromAnyContext(ParserRuleContext context)
        {
            if (context == null)
                return null;
            return new CodeFragment(TerminalSymbols.FromNode(context));
        }
    }
}
