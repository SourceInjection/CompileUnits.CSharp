using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class EnumMemberDefinition
    {
        internal EnumMemberDefinition(string name, Expression value, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            Value = value;
            AttributeGroups = attributeGroups;
        }

        public EnumDefinition ContainingType { get; internal set; }

        public string Name { get; }

        public Expression Value { get; }

        public IReadOnlyList<AttributeGroup> AttributeGroups { get; }

        public string FullName() => $"{ContainingType.FullName()}.{Name}";
    }
}
