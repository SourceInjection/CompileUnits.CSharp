using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IMember
    {
        MemberKind MemberKind { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        IReadOnlyList<IAttributeUsage> Attributes { get; }

        IType ContainingType { get; }

        string Name { get; }

        AccessModifier AccessModifier { get; }
    }

    public static class IMemberExtensions
    {
        public static bool IsKind(this IMember member, MemberKind kind) => member.MemberKind == kind;

        public static bool HasAccessability(this IMember member, AccessModifier modifier) => member.AccessModifier == modifier;
    }
}
