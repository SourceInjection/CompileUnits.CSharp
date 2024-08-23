using System.Collections.Generic;
using System.Text;

namespace CompileUnits.CSharp.Implementation.Common
{
    internal static class Text
    {
        public static string TypeUsage(IEnumerable<TerminalSymbol> symbols)
        {
            var sb = new StringBuilder();

            TerminalSymbol prev = null;

            foreach (var item in symbols)
            {
                if (IsComma(prev) && !IsCommaOrCloseSymbol(item))
                    sb.Append(' ');
                sb.Append(item.Value);
                prev = item;
            }
            return sb.ToString();
        }

        private static bool IsComma(TerminalSymbol symbol) => symbol?.Kind is TerminalSymbolKind.Comma;

        private static bool IsCommaOrCloseSymbol(TerminalSymbol symbol)
        {
            return symbol.IsKind(TerminalSymbolKind.CloseBracket)
                || symbol.IsKind(TerminalSymbolKind.Comma)
                || symbol.IsKind(TerminalSymbolKind.GreaterThanOperator)
                || symbol.IsKind(TerminalSymbolKind.CloseParenthese);
        }
    }
}
