using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class PropertyDefinition: MemberDefinition
    {
        internal PropertyDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type, 
            bool isAbstract, 
            bool isVirtual, 
            bool isOverride)

            : base(name, accessModifier, hasNewModifier, attributeGroups)
        {
            Type = type;
            IsAbstract = isAbstract;
            IsVirtual = isVirtual;
            IsOverride = isOverride;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Property;

        public TypeUsage Type { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }
    }
}
