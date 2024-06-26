using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public abstract class AccessorDefinition
    {
        protected private AccessorDefinition(
            string name, 
            AccessModifier accessModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            IReadOnlyList<AttributeUsage> attributes, 
            Code body)
        {
            Name = name;
            AccessModifier = accessModifier;
            AttributeGroups = attributeGroups;
            Attributes = attributes;
            Body = body;
        }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<AttributeUsage> Attributes { get; }

        public Code Body { get; }
    }
}
