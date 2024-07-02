using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IGenericTypeArgument
    {
        string Name { get; }

        Variance Variance { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }
    }
}
