using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents code fragments like method bodies, expressions, arrow functions etc..
    /// </summary>
    public interface ICodeFragment
    {
        /// <summary>
        /// Lists the terminal symbols of the code fragment.
        /// </summary>
        IReadOnlyList<ITerminalSymbol> Symbols { get; }
    }
}
