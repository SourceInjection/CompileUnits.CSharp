using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
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
                  name:            name, 
                  accessModifier:  accessModifier, 
                  hasNewModifier:  hasNewModifier, 
                  attributeGroups: attributeGroups)
        {
            foreach(var member in members)
                member.ContainingType = this;

            GenericTypeArguments = genericTypeArguments;
            ConstraintClauses = constraints;
            Members = members;

            Constructors = members.OfType<ConstructorDefinition>().ToArray();
            Fields = members.OfType<FieldDefinition>().ToArray();
            Properties = members.OfType<PropertyDefinition>().ToArray();
            Methods = members.OfType<MethodDefinition>().ToArray();
            Types = members.OfType<TypeDefinition>().ToArray();
            Constants = members.OfType<ConstantDefinition>().ToArray();
            Indexers = members.OfType<IndexerDefinition>().ToArray();
            Events = members.OfType<EventDefinition>().ToArray();
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
    }
}
