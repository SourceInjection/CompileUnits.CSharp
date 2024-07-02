using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IEnumMember
    {
        IEnum ContainingType { get; }

        string Name { get; }

        ICodeFragment Value { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }
    }
}
