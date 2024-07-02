using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Members.Types.Generics;

namespace CodeUnits.CSharp.Implementation.Members.Types
{
    public abstract class StructuredTypeDefinition : TypeDefinition
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

        public IReadOnlyList<MemberDefinition> Members { get; }

        public IReadOnlyList<TypeDefinition> Types { get; }

        public IReadOnlyList<ConstantDefinition> Constants { get; }

        public IReadOnlyList<FieldDefinition> Fields { get; }

        public IReadOnlyList<ConstructorDefinition> Constructors { get; }

        public IReadOnlyList<PropertyDefinition> Properties { get; }

        public IReadOnlyList<MethodDefinition> Methods { get; }

        public IReadOnlyList<GenericTypeArgumentDefinition> GenericTypeArguments { get; }

        public IReadOnlyList<ConstraintDefinition> ConstraintClauses { get; }

        public IReadOnlyList<IndexerDefinition> Indexers { get; }

        public IReadOnlyList<EventDefinition> Events { get; }

        public IReadOnlyList<OperatorDefinition> Operators { get; }

        public IReadOnlyList<ConversionOperatorDefinition> ConversionOperators { get; }
    }
}
