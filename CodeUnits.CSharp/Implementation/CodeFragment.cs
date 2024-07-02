using Antlr4.Runtime;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation
{
    public class CodeFragment : ICodeFragment
    {
        private CodeFragment(IReadOnlyList<TerminalSymbol> symbols)
        {
            Symbols = symbols;
        }

        public IReadOnlyList<ITerminalSymbol> Symbols { get; }

        public static CodeFragment FromContext(Throwable_expressionContext context)
        {
            if (context == null)
                return null;

            var arrow = new TerminalSymbol(TerminalSymbolKind.RightArrow, "=>");
            var semiColon = new TerminalSymbol(TerminalSymbolKind.Semicolon, ";");
            var tokens = Common.Symbols.FromNode(context)
                .Prepend(arrow)
                .Append(semiColon)
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
            return new CodeFragment(Common.Symbols.FromNode(context));
        }
    }
}
