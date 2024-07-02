using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IAttributeGroup
    {
        string AttributeTarget { get; }

        IReadOnlyList<IAttributeUsage> Attributes { get; }
    }
}
