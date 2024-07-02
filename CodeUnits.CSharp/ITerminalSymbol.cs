namespace CodeUnits.CSharp
{
    public interface ITerminalSymbol
    {
        string Value { get; }

        TerminalSymbolKind Kind { get; }
    }

    public static class ITerminalSymbolExtensions
    {
        public static bool IsKind(this ITerminalSymbol symbol, TerminalSymbolKind kind) 
            => symbol.Kind == kind;
    }
}
