using System.Collections.Generic;
using System.Linq;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation
{
    internal class Body : CodeFragment, IBody
    {
        private Body(IReadOnlyList<TerminalSymbol> terminalSymbols, BodyKind bodyKind)
            : base(terminalSymbols, FragmentKind.Body) 
        { 
            BodyKind = bodyKind;
        }

        public BodyKind BodyKind { get; }

        public static Body FromContext(Throwable_expressionContext context)
        {
            return new Body(
                TerminalSymbols.FromNode(context)
                    .Prepend(new TerminalSymbol(TerminalSymbolKind.RightArrow, "=>"))
                    .Append(new TerminalSymbol(TerminalSymbolKind.Semicolon, ";"))
                    .ToArray(), 
                BodyKind.Arrow);
        }

        public static Body FromContext(BodyContext context)
        {
            return context?.block() != null
                ? FromContext(context.block())
                : null;
        }

        public static Body FromContext(BlockContext context)
        {
            if (context == null)
                return null;
            return new Body(TerminalSymbols.FromNode(context), BodyKind.Block);
        }
    }
}
