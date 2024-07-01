using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class EnumDefinition : TypeDefinition
    {
        internal EnumDefinition(
            string name, 
            AccessModifier accessModifier, 
            bool hasNewModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<EnumMemberDefinition> members, 
            TypeUsage baseType)
            
            : base(
                  name:            name, 
                  accessModifier:  accessModifier, 
                  hasNewModifier:  hasNewModifier, 
                  attributeGroups: attributeGroups)
        {
            foreach (var member in members)
                member.ContainingType = this;

            Members = members;
            BaseType = baseType;
        }

        public IReadOnlyList<EnumMemberDefinition> Members { get; }

        public override TypeKind TypeKind { get; } = TypeKind.Enum;

        public TypeUsage BaseType { get; }
    }
}
