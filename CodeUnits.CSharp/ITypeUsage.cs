using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    /// <summary>
    /// Represents the usage of a type.
    /// </summary>
    public interface ITypeUsage
    {
        /// <summary>
        /// Lists all terminal symbol within the type usage.
        /// </summary>
        IReadOnlyList<ITerminalSymbol> Symbols { get; }

        /// <summary>
        /// Represents the type usage as formated <see langword="string"/>.
        /// </summary>
        string FormatedText { get; }
    }
}
