namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents a terminal symbol.
    /// Terminal symbols are all symbols that can apear within a .cs file.
    /// </summary>
    public interface ITerminalSymbol
    {
        /// <summary>
        /// The value of the terminal symbol.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// The kind of the symbol.
        /// </summary>
        TerminalSymbolKind Kind { get; }
    }

    public static class ITerminalSymbolExtensions
    {
        /// <summary>
        /// Checks if the terminal symbol is of the desired kind.
        /// </summary>
        /// <param name="symbol">The terminal symbol to be checked.</param>
        /// <param name="kind">The desired kind.</param>
        /// <returns><see langword="true"/> if the terminal symbol is of the desired kind else <see langword="false"/></returns>
        public static bool IsKind(this ITerminalSymbol symbol, TerminalSymbolKind kind) 
            => symbol.Kind == kind;
    }
}
