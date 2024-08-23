using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    internal class FieldDefinition : MemberDefinition, IField
    {
        internal FieldDefinition(
            string name,
            AccessModifier accessModifier,
            bool hasNewModifier,
            IReadOnlyList<AttributeGroup> attributeGroups,
            TypeUsage type,
            bool isStatic,
            bool isReadonly,
            Expression defaultValue)

            : base(
                  name: name,
                  modifier: accessModifier,
                  attributeGroups: attributeGroups)
        {
            Type = type;
            IsStatic = isStatic;
            IsReadonly = isReadonly;
            Initialization = defaultValue;
            HasNewModifier = hasNewModifier;
            type.ParentNode = this;
            if (defaultValue != null)
                defaultValue.ParentNode = this;
        }

        public override MemberKind MemberKind { get; } = MemberKind.Field;

        public ITypeUsage Type { get; }

        public bool IsStatic { get; }

        public bool IsReadonly { get; }

        public IExpression Initialization { get; }

        public bool HasNewModifier { get; }

        public override IEnumerable<ITreeNode> ChildNodes()
        {
            var result = base.ChildNodes()
                .Append(Type);
            if (Initialization != null)
                result = result.Append(Initialization);
            return result;
        }

        internal static FieldDefinition FromContext(Variable_declaratorContext context, FieldDefinitionInfo fieldInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new FieldDefinition(
                name: context.identifier().GetText(),
                accessModifier: fieldInfo.Modifiers.AccessModifier,
                hasNewModifier: fieldInfo.Modifiers.HasNewModifier,
                attributeGroups: fieldInfo.AttributeGroups,
                type: fieldInfo.Type,
                isStatic: fieldInfo.Modifiers.IsStatic,
                isReadonly: fieldInfo.Modifiers.IsReadonly,
                defaultValue: Expression.FromContext(context.variable_initializer()));
        }
    }
}
