using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface ITypeUsage
    {
        IReadOnlyList<ITerminalSymbol> Symbols { get; }

        string FormatedText { get; }
    }
}
