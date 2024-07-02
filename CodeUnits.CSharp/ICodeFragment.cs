using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface ICodeFragment
    {
        IReadOnlyList<ITerminalSymbol> Symbols { get; }
    }
}
