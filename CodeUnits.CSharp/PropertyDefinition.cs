using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public class PropertyDefinition: MemberDefinition
    {
        private protected PropertyDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type, 
            bool isAbstract, 
            bool isVirtual, 
            bool isOverride,
            bool hasRefModifier,
            GetterDefinition getter,
            SetterDefinition setter)

            : base(name, accessModifier, attributeGroups)
        {
            Type = type;
            IsAbstract = isAbstract;
            IsVirtual = isVirtual;
            IsOverride = isOverride;
            HasRefModifier = hasRefModifier;
            Getter = getter;
            Setter = setter;
            HasNewModifier = hasNewModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Property;

        public TypeUsage Type { get; }

        public bool IsAbstract { get; }

        public bool IsVirtual { get; }

        public bool IsOverride { get; }

        public bool HasRefModifier { get; }

        public GetterDefinition Getter { get; }

        public SetterDefinition Setter { get; }

        public bool HasNewModifier { get; }
    }
}
