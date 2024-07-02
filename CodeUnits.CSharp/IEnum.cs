using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IEnum
    {
        MemberKind MemberKind { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        IReadOnlyList<IAttributeUsage> Attributes { get; }

        IType ContainingType { get; }

        string Name { get; }

        AccessModifier AccessModifier { get; }
    }
}
