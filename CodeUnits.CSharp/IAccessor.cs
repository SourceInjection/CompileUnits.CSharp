using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public interface IAccessor
    {
        string Name { get; }

        AccessModifier AccessModifier { get; }

        IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        IReadOnlyList<IAttributeUsage> Attributes { get; }

        AccessorKind Kind { get; }

        ICodeFragment Body { get; }
    }

    public static class IAccessorExtensions
    {
        public static bool IsKind(this IAccessor accessor, AccessorKind kind) => accessor.Kind == kind;
    }
}
