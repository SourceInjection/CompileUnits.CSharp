using System.Collections.Generic;
using System.Linq;
using CodeUnits.CSharp.Implementation.Attributes;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class ConstantDefinition : MemberDefinition, IConstant
    {
        internal ConstantDefinition(
            string name,
            AccessModifier modifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            CodeFragment value)

            : base(
                  name: name,
                  modifier: modifier,
                  attributeGroups: attributeGroups)
        {
            Type = type;
            Value = value;
            HasNewModifier = hasNewModifier;
            type.ParentNode = this;
            value.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Constant;

        public ITypeUsage Type { get; }

        public ICodeFragment Value { get; }

        public bool HasNewModifier { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            return base.ChildNodes()
                .Append(Type)
                .Append(Value);
        }
    }
}
