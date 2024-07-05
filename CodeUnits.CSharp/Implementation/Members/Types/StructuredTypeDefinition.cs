using System.Collections.Generic;
using System.Linq;
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
            GenericTypeArguments = genericTypeArguments;
            Constraints = constraints;
            Members = members;
            Inheritance = inheritance;

            foreach (var member in members)
                member.ContainingType = this;
            foreach (var genAttr in genericTypeArguments)
                genAttr.ParentNode = this;
            foreach(var constraint in constraints)
                constraint.ParentNode = this;
            foreach (var item in inheritance)
                item.ParentNode = this;
        }

        public IReadOnlyList<IMember> Members { get; }

        public IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        public IReadOnlyList<IConstraint> Constraints { get; }

        public IReadOnlyList<ITypeUsage> Inheritance { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            return base.ChildNodes()
                .Concat(GenericTypeArguments)
                .Concat(Inheritance)
                .Concat(Constraints)
                .Concat(Members);
        }
    }
}
