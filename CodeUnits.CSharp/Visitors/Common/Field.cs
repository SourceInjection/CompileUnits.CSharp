
using CodeUnits.CSharp.Visitors.ValueTypes;
using System;
using static CodeUnits.CSharp.Generated.CSharpParser;

namespace CodeUnits.CSharp.Visitors.Common
{
    internal static class Field
    {
        public static FieldDefinition FromContext(Variable_declaratorContext context, FieldDefinitionInfo fieldInfo)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Expression defaultValue = null;
            if (context.variable_initializer() != null)
            {
                if (context.variable_initializer().expression() != null)
                    defaultValue = new Expression(context.variable_initializer().expression());
                else if (context.variable_initializer().array_initializer() != null)
                    defaultValue = new Expression(context.variable_initializer().array_initializer());
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
