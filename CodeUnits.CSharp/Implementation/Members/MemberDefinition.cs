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
        }

        public abstract MemberKind MemberKind { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public virtual IType ContainingType { get; internal set; }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }
    }
}
