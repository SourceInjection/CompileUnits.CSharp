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

            : base(name, modifier, attributeGroups)
        {
            Type = type;
            Value = value;
            HasNewModifier = hasNewModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Constant;

        public TypeUsage Type { get; }

        public Expression Value { get; }

        public bool HasNewModifier { get; }
    }
}
