using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members.Minor
{
    internal class EnumMemberDefinition : IEnumMember
    {
        internal EnumMemberDefinition(string name, CodeFragment value, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            Value = value;
            AttributeGroups = attributeGroups;
        }

        public IEnum ContainingType { get; internal set; }

        public string Name { get; }

        public ICodeFragment Value { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }
    }
}
