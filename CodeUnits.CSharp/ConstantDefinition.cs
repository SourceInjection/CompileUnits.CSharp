using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class ConstantDefinition : MemberDefinition
    {
        internal ConstantDefinition(
            string name, 
            AccessModifier modifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            Expression value) 

            : base(name, modifier, hasNewModifier, attributeGroups)
        {
            Type = type;
            Value = value;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Constant;

        public TypeUsage Type { get; }

        public Expression Value { get; }
    }
}
