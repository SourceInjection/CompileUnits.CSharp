using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IAttributeUsage
    {
        IAttributeGroup ContainingSection { get;  }

        string Name { get; }

        IReadOnlyList<IArgument> Arguments { get; }
    }
}
