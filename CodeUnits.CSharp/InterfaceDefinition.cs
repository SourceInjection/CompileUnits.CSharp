using System.Collections.Generic;

namespace CodeUnits.CSharp.Visitors
{
    public sealed class InterfaceDefinition: StructuredTypeDefinition
    {
        internal InterfaceDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints)

            : base(
                  name:                 name,
                  accessModifier:       accessModifier, 
                  hasNewModifier:       hasNewModifier, 
                  attributeGroups:      attributeGroups, 
                  members:              members, 
                  genericTypeArguments: genericTypeArguments, 
                  constraints:          constraints)
        { }

        public override TypeKind TypeKind { get; } = TypeKind.Interface;
    }
}
