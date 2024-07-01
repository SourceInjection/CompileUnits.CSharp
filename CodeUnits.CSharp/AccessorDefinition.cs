using System.Collections.Generic;
using System.Linq;

namespace CodeUnits.CSharp
{
    public enum AccessorKind { Getter, Setter }

    public sealed class AccessorDefinition
    {
        internal AccessorDefinition(
            string name, 
            AccessModifier accessModifier, 
            IReadOnlyList<AttributeGroup> attributeGroups, 
            Code body,
            AccessorKind kind)
        {
            Name = name;
            AccessModifier = accessModifier;
            AttributeGroups = attributeGroups;
            Attributes = AttributeGroups.SelectMany(a => a.Attributes).ToArray();
            Body = body;
            Kind = kind;
        }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<AttributeUsage> Attributes { get; }

        public AccessorKind Kind { get; }

        public Code Body { get; }

        public bool IsKind(AccessorKind kind) => Kind == kind;
    }
}
