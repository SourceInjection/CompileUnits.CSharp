using CodeUnits.CSharp.Implementation.Attributes;
using CodeUnits.CSharp.Implementation.Common;
using System;
using System.Collections.Generic;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Implementation.Members
{
    public sealed class FieldDefinition : MemberDefinition, IField
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
            CodeFragment defaultValue)

            : base(
                  name: name,
                  modifier: accessModifier,
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

        public ITypeUsage Type { get; }

        public bool IsStatic { get; }

        public bool IsReadonly { get; }

        public bool IsNew { get; }

        public ICodeFragment DefaultValue { get; }

        public bool HasNewModifier { get; }

        internal static FieldDefinition FromContext(Variable_declaratorContext context, FieldDefinitionInfo fieldInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            CodeFragment defaultValue = null;
            if (context.variable_initializer() != null)
            {
                if (context.variable_initializer().expression() != null)
                    defaultValue = CodeFragment.FromContext(context.variable_initializer().expression());
                else if (context.variable_initializer().array_initializer() != null)
                    defaultValue = CodeFragment.FromContext(context.variable_initializer().array_initializer());
            }

            return new FieldDefinition(
                name: context.identifier().GetText(),
                accessModifier: fieldInfo.Modifiers.AccessModifier,
                hasNewModifier: fieldInfo.Modifiers.HasNewModifier,
                attributeGroups: fieldInfo.AttributeGroups,
                type: fieldInfo.Type,
                isStatic: fieldInfo.Modifiers.IsStatic,
                isReadonly: fieldInfo.Modifiers.IsReadonly,
                isNew: fieldInfo.Modifiers.HasNewModifier,
                defaultValue: defaultValue);
        }
    }
}
