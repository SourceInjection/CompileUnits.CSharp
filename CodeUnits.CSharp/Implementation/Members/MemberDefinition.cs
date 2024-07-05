using System.Collections.Generic;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal abstract class MemberDefinition : IMember
    {
        protected private MemberDefinition(string name, AccessModifier modifier, IReadOnlyList<AttributeGroup> attributeGroups)
        {
            Name = name;
            AccessModifier = modifier;
            AttributeGroups = attributeGroups;
            foreach (var attributeGroup in attributeGroups)
                attributeGroup.ParentNode = this;
        }

        public abstract MemberKind MemberKind { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public virtual IType ContainingType { get; internal set; }

        public virtual ITreeNode ParentNode => ContainingType;

        public string Name { get; }

        public AccessModifier AccessModifier { get; }

        public virtual IEnumerable<ITreeNode> ChildNodes()
        {
            return AttributeGroups;
        }
    }
}
