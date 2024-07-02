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
            IReadOnlyList<ConstraintDefinition> constraints)

            : base(
                  name: name,
                  accessModifier: accessModifier,
                  hasNewModifier: hasNewModifier,
                  attributeGroups: attributeGroups)
        {
            foreach (var member in members)
                member.ContainingType = this;

            GenericTypeArguments = genericTypeArguments;
            ConstraintClauses = constraints;
            Members = members;

            Types = members.OfType<TypeDefinition>().ToArray();
            Properties = members.OfType<PropertyDefinition>().ToArray();
            Fields = members.OfType<FieldDefinition>().ToArray();
            Methods = members.OfType<MethodDefinition>().ToArray();
            Constructors = members.OfType<ConstructorDefinition>().ToArray();
            Operators = members.OfType<OperatorDefinition>().ToArray();
            ConversionOperators = members.OfType<ConversionOperatorDefinition>().ToArray();
            Indexers = members.OfType<IndexerDefinition>().ToArray();
            Events = members.OfType<EventDefinition>().ToArray();
            Constants = members.OfType<ConstantDefinition>().ToArray();
        }

        public IReadOnlyList<IMember> Members { get; }

        public IReadOnlyList<IType> Types { get; }

        public IReadOnlyList<IConstant> Constants { get; }

        public IReadOnlyList<IField> Fields { get; }

        public IReadOnlyList<IConstructor> Constructors { get; }

        public IReadOnlyList<IProperty> Properties { get; }

        public IReadOnlyList<IMethod> Methods { get; }

        public IReadOnlyList<IGenericTypeArgument> GenericTypeArguments { get; }

        public IReadOnlyList<IConstraint> ConstraintClauses { get; }

        public IReadOnlyList<IIndexer> Indexers { get; }

        public IReadOnlyList<IEvent> Events { get; }

        public IReadOnlyList<IOperator> Operators { get; }

        public IReadOnlyList<IConversionOperator> ConversionOperators { get; }
    }
}
