using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    internal abstract class StructuredTypeDefinition : TypeDefinition, IStructuredType
    {
        protected private StructuredTypeDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            IReadOnlyList<MemberDefinition> members,
            IReadOnlyList<GenericTypeArgumentDefinition> genericTypeArguments,
            IReadOnlyList<ConstraintDefinition> constraints,
            IReadOnlyList<TypeUsage> inheritance)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups)
        {
            foreach (var member in members)
                member.ContainingType = this;

            GenericTypeArguments = genericTypeArguments;
            Constraints = constraints;
            Members = members;
            Inheritance = inheritance;
        }

        public IReadOnlyList<IMember> Members { get; }

        public IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        public IReadOnlyList<IConstraint> Constraints { get; }

        public IReadOnlyList<ITypeUsage> Inheritance { get; }
    }
}
