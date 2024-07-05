using System.Collections.Generic;
using System.Linq;
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
            foreach (var attr in attributeGroups)
                attr.ParentNode = this;
            if (value != null)
                value.ParentNode = this;
        }

        public IEnum ContainingType { get; internal set; }

        public ITreeNode ParentNode => ContainingType;

        public string Name { get; }

        public ICodeFragment Value { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public IEnumerable<ITreeNode> ChildNodes()
        {
            IEnumerable<ITreeNode> result = AttributeGroups;
            if(Value != null)
                result = result.Append(Value);
            return result;
        }
    }
}
