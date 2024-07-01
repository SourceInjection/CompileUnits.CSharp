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
            InheritanceModifier inheritanceModifier,
            bool hasRefModifier,
            AccessorDefinition getter,
            AccessorDefinition setter, 
            TypeUsage addressedInterface,
            Expression defaultValue)

            : base(
                  name:            name, 
                  modifier:        accessModifier, 
                  attributeGroups: attributeGroups)
        {
            Type = type;
            HasRefModifier = hasRefModifier;
            Getter = getter;
            Setter = setter;
            HasNewModifier = hasNewModifier;
            AddressedInterface = addressedInterface;
            InheritanceModifier = inheritanceModifier;
            DefaultValue = defaultValue;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Property;

        public TypeUsage Type { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public AccessorDefinition Getter { get; }

        public AccessorDefinition Setter { get; }

        public bool HasNewModifier { get; }

        public TypeUsage AddressedInterface { get; }

        public Expression DefaultValue { get; }
    }
}
