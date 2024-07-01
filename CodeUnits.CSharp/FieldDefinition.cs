using System.Collections.Generic;

namespace CodeUnits.CSharp
{
    public sealed class FieldDefinition: MemberDefinition
    {
        internal FieldDefinition(
            string name, 
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            bool isStatic, 
            bool isReadonly, 
            bool isNew,
            Expression defaultValue)

            : base(
                  name:            name, 
                  modifier:        accessModifier, 
                  attributeGroups: attributeGroups)
        {
            Type = type;
            IsStatic = isStatic;
            IsReadonly = isReadonly;
            IsNew = isNew;
            DefaultValue = defaultValue;
            HasNewModifier = hasNewModifier;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Field;

        public TypeUsage Type { get; }

        public bool IsStatic { get; }

        public bool IsReadonly { get; }

        public bool IsNew { get; }

        public Expression DefaultValue { get; }

        public bool HasNewModifier { get; }
    }
}
