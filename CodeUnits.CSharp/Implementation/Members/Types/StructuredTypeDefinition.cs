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
            foreach (var member in members)
                member.ContainingType = this;

            GenericTypeArguments = genericTypeArguments;
            Constraints = constraints;
            Members = members;
            Inheritance = inheritance;

            Types = members.OfType<TypeDefinition>().ToArray();
            Properties = members.OfType<PropertyDefinition>().ToArray();
            Methods = members.OfType<MethodDefinition>().ToArray();
            Operators = members.OfType<OperatorDefinition>().ToArray();
            Indexers = members.OfType<IndexerDefinition>().ToArray();
            Events = members.OfType<EventDefinition>().ToArray();
            Constants = members.OfType<ConstantDefinition>().ToArray();
        }

        public IReadOnlyList<IMember> Members { get; }

        public IReadOnlyList<IType> Types { get; }

        public IReadOnlyList<IConstant> Constants { get; }

        public IReadOnlyList<IProperty> Properties { get; }

        public IReadOnlyList<IMethod> Methods { get; }

        public IReadOnlyList<IGenericTypeParameter> GenericTypeArguments { get; }

        public IReadOnlyList<IConstraint> Constraints { get; }

        public IReadOnlyList<IIndexer> Indexers { get; }

        public IReadOnlyList<IEvent> Events { get; }

        public IReadOnlyList<IOperator> Operators { get; }

        public IReadOnlyList<ITypeUsage> Inheritance { get; }
    }
}
