using System.Collections.Generic;
using static CompileUnits.CSharp.Generated.CSharpParser;

namespace CompileUnits.CSharp.Implementation
{
    internal class Expression : CodeFragment, IExpression
    {
        private Expression(IReadOnlyList<TerminalSymbol> symbols) 
            : base(symbols, FragmentKind.Expression)
        { }

        public static Expression FromContext(Variable_initializerContext context)
        {
            if (context == null)
                return null;

            if (context.expression() != null)
                return FromContext(context.expression());
            return new Expression(TerminalSymbols.FromNode(context.array_initializer()));
        }

        public static Expression FromContext(ExpressionContext context)
        {
            if (context == null) 
                return null;
            return new Expression(TerminalSymbols.FromNode(context));
        }
    }
}
