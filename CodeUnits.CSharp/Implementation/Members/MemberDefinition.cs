using System.Collections.Generic;
using System.Linq;
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
            Attributes = attributeGroups.SelectMany(a => a.Attributes).ToArray();
        }

        public abstract MemberKind MemberKind { get; }

        public IReadOnlyList<IAttributeGroup> AttributeGroups { get; }

        public IReadOnlyList<IAttribute> Attributes { get; }

        public virtual IType ContainingType { get; internal set; }

        public string Name { get; }

        public AccessModifier AccessModifier { get; }
    }
}
