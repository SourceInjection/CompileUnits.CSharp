using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class IndexerDefinition: MemberDefinition
    {
        internal IndexerDefinition(
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            InheritanceModifier inheritanceModifier,
            bool hasRefModifier, 
            AccessorDefinition getter,
            AccessorDefinition setter,
            TypeUsage addressedInterface) 
            
            : base(
                  name:            "[]", 
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
        }

        public override MemberKind MemberKind { get; } = MemberKind.Indexer;

        public TypeUsage Type { get; }

        public InheritanceModifier InheritanceModifier { get; }

        public bool HasRefModifier { get; }

        public AccessorDefinition Getter { get; }

        public AccessorDefinition Setter { get; }

        public bool HasNewModifier { get; }

        public TypeUsage AddressedInterface { get; }
    }
}
